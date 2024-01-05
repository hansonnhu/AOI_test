using System.Diagnostics;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using IniParser;
using IniParser.Model;


namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        public int marginSize = 50;
        private String imgPath;
        private Bitmap oriImg;
        private Bitmap targetImg;
        private Bitmap positionedImg;
        private bool isDrawing = false;
        private bool isMouseDown = false;
        private Rectangle currentRect;
        private String rootPath = "";
        private String parameterFileName = "default_parameter.ini";

        // new 一些 class
        ImgToBinary imgToBinary = new ImgToBinary();
        BlobSelector blobSelector = new BlobSelector();


        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // 讀取 ini 參數檔案，並且寫入參數
            var parser = new FileIniDataParser();
            Dictionary<String, Object> parameter = new Dictionary<String, Object>();
            rootPath = System.Environment.CurrentDirectory.ToString().Split("\\WinFormsApp1\\bin\\")[0];// 跟目錄 path 設定

            var parameterPath = rootPath + "\\parameter\\" + parameterFileName;
            openParameterFilePathLabel.Text = parameterPath.Split("\\")[parameterPath.Split("\\").Length - 1];


            loadParameterFile(parameterPath);


            // 每個物件的 margin 設定，與物件初始值設定
            int marginSize = 50;


            // 讓視窗全螢幕
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;

            // pixel數值Group的起始位置
            pixelInfoGroup.Location = new System.Drawing.Point(marginSize, Screen.PrimaryScreen.Bounds.Height - pixelInfoGroup.Height - marginSize);
            saveGroup.Location = new System.Drawing.Point(30, Screen.PrimaryScreen.Bounds.Height - saveGroup.Height - 3 * marginSize);
            parameterFileGroup.Location = new System.Drawing.Point(parameterFileGroup.Location.X, Screen.PrimaryScreen.Bounds.Height - saveGroup.Height - 3 * marginSize);
            // 影像畫布的位置與大小
            panel1.Location = new System.Drawing.Point(marginSize, marginSize);
            panel1.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width / 2 - 2 * marginSize, Screen.PrimaryScreen.Bounds.Width / 2 - 2 * marginSize);

            // 右方操作鈕Group的大小與起始位置
            functionBtnGroup.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 2 * marginSize, marginSize);
            functionBtnGroup.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width / 2 - 3 * marginSize, Screen.PrimaryScreen.Bounds.Height - 2 * marginSize);
        }

        public void setConsoleInfo()
        {
            // console 當前參數
            consoleLabel.Text = "";// 先清空
            consoleLabel.Text += "當前參數\n\n";

            consoleLabel.Text += "blobDetect 部分\n";
            consoleLabel.Text += "imgBinaryWay : " + imgToBinary.binaryWay + "\n";
            consoleLabel.Text += "InRangeUpperBound : " + imgToBinary.inRangeUpperBound + "\n";
            consoleLabel.Text += "InRangeLowerBound : " + imgToBinary.inRangeLowerBound + "\n";
            consoleLabel.Text += "invertBinaryFlag : " + imgToBinary.invertBinaryFlag + "\n";
            consoleLabel.Text += "DilateFlag : " + imgToBinary.dilateFlag + "\n";
            consoleLabel.Text += "ErodeFlag : " + imgToBinary.erodeFlag + "\n";
            consoleLabel.Text += "Dilate_Erode_Mask_Size : " + imgToBinary.dilateErodeMaskSize + "\n";
            consoleLabel.Text += "Dilate_Erode_Direction : " + imgToBinary.dilateErodeDirection + "\n";
            consoleLabel.Text += "blob_maxArea : " + blobSelector.blobMaxArea + "\n";
            consoleLabel.Text += "blob_minRadius : " + blobSelector.blobMinRadius + "\n";
            consoleLabel.Text += "blob_maxRadius : " + blobSelector.blobMaxRadius + "\n";
            consoleLabel.Text += "blobAreaRatio : " + blobSelector.blobAreaRatioThreshold + "\n";
            consoleLabel.Text += "findContoursWay : " + blobSelector.findContoursWay + "\n";
        }

        public void loadParameterFile(String iniFilePath)
        {
            // 讀取參數檔，並且將數值更新於介面
            if (File.Exists(iniFilePath))
            {
                // 讀取參數檔
                var parser = new FileIniDataParser();
                consoleLabel.Text = "已讀取參數檔 : " + "parameter1.ini" + "\n";
                var data = parser.ReadFile(iniFilePath);

                // 賦予 imgToBinary class 參數
                imgToBinary.binaryWay = data["imgBinary"]["imgBinaryWay"];
                imgToBinary.inRangeUpperBound = int.Parse(data["imgBinary"]["InRangeUpperBound"]);
                imgToBinary.inRangeLowerBound = int.Parse(data["imgBinary"]["InRangeLowerBound"]);
                imgToBinary.invertBinaryFlag = int.Parse(data["imgBinary"]["invertBinaryFlag"]) == 1 ? true : false;
                imgToBinary.dilateFlag = int.Parse(data["imgBinary"]["DilateFlag"]) == 1 ? true : false;
                imgToBinary.erodeFlag = int.Parse(data["imgBinary"]["ErodeFlag"]) == 1 ? true : false;
                imgToBinary.dilateErodeMaskSize = int.Parse(data["imgBinary"]["Dilate_Erode_Mask_Size"]);
                imgToBinary.dilateErodeDirection = data["imgBinary"]["Dilate_Erode_Direction"];

                // 賦予 blobSelector class 參數
                blobSelector.blobMaxArea = int.Parse(data["blobDetect"]["blob_maxArea"]);
                blobSelector.blobMinRadius = int.Parse(data["blobDetect"]["blob_minRadius"]);
                blobSelector.blobMaxRadius = int.Parse(data["blobDetect"]["blob_maxRadius"]);
                blobSelector.blobAreaRatioThreshold = (double)int.Parse(data["blobDetect"]["blobAreaRatio"]) / 100;
                blobSelector.findContoursWay = data["blobDetect"]["findContoursWay"];



                // 將 blobDetect 數值更新於介面
                blobDetect_InRangeUpperBoundScrollBar.Value = imgToBinary.inRangeUpperBound;
                blobDetect_InRangeUpperBoundLabel.Text = imgToBinary.inRangeUpperBound.ToString();

                blobDetect_InRangeLowerBoundScrollBar.Value = imgToBinary.inRangeLowerBound;
                blobDetect_InRangeLowerBoundLabel.Text = imgToBinary.inRangeLowerBound.ToString();

                blobDetect_invertBinaryFlagCheckBox.Checked = imgToBinary.invertBinaryFlag;

                blob_maxAreaBar.Value = blobSelector.blobMaxArea;
                blob_maxAreaLabel.Text = blobSelector.blobMaxArea.ToString();

                blob_minRadiusBar.Value = blobSelector.blobMinRadius;
                blob_minRadiusLabel.Text = blobSelector.blobMinRadius.ToString();

                blobDetect_DilateFlagCheckBox.Checked = imgToBinary.dilateFlag;
                blobDetect_ErodeFlagCheckBox.Checked = imgToBinary.erodeFlag;
                blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Value = imgToBinary.dilateErodeMaskSize;

                Dilate_Erode_Direction_ComboBox.SelectedItem = Dilate_Erode_Direction_ComboBox.Items.Cast<dynamic>().FirstOrDefault(x => x == imgToBinary.dilateErodeDirection);

                blob_maxRadiusBar.Value = blobSelector.blobMaxRadius;
                blob_maxRadiusLabel.Text = blobSelector.blobMaxRadius.ToString();

                blobAreaRatioBar.Value = Convert.ToInt32(blobSelector.blobAreaRatioThreshold * 100);
                blob_AreaRatioLabel.Text = blobSelector.blobAreaRatioThreshold.ToString();

                FindContoursWayComboBox.SelectedItem = FindContoursWayComboBox.Items.Cast<dynamic>().FirstOrDefault(x => x == blobSelector.findContoursWay);

                setConsoleInfo();
            }
        }

        private void saveParameterBtn_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            var data = new IniData();
            data["imgBinary"]["imgBinaryWay"] = imgToBinary.binaryWay;
            data["imgBinary"]["InRangeUpperBound"] = imgToBinary.inRangeUpperBound.ToString();
            data["imgBinary"]["InRangeLowerBound"] = imgToBinary.inRangeLowerBound.ToString();
            data["imgBinary"]["DilateFlag"] = imgToBinary.dilateFlag ? "1" : "0";
            data["imgBinary"]["ErodeFlag"] = imgToBinary.erodeFlag ? "1" : "0";
            data["imgBinary"]["Dilate_Erode_Mask_Size"] = imgToBinary.dilateErodeMaskSize.ToString();
            data["imgBinary"]["Dilate_Erode_Direction"] = imgToBinary.dilateErodeDirection;
            data["imgBinary"]["invertBinaryFlag"] = imgToBinary.invertBinaryFlag ? "1" : "0";

            data["blobDetect"]["blob_maxArea"] = blobSelector.blobMaxArea.ToString();
            data["blobDetect"]["blob_minRadius"] = blobSelector.blobMinRadius.ToString();
            data["blobDetect"]["blob_maxRadius"] = blobSelector.blobMaxRadius.ToString();
            data["blobDetect"]["blobAreaRatio"] = ((int)(blobSelector.blobAreaRatioThreshold * 100)).ToString();
            data["blobDetect"]["findContoursWay"] = blobSelector.findContoursWay;
            

            try
            {
                parser.WriteFile(rootPath + "\\parameter\\" + saveParameterLabel.Text + ".ini", data);
                MessageBox.Show("儲存參數成功 !");
            }
            catch
            {
                MessageBox.Show("儲存失敗");
            }

        }

        public void resizePanel(Bitmap img, Panel panel1)
        {
            //Resize 顯示影像的panel大小
            panel1.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width / 2 - 2 * marginSize, Screen.PrimaryScreen.Bounds.Width / 2 - 2 * marginSize);
            if (img.Width > img.Height)
            {
                panel1.Size = new System.Drawing.Size(panel1.Width, (panel1.Height * img.Height / img.Width));
            }
            else
            {
                panel1.Size = new System.Drawing.Size((panel1.Width * img.Width / img.Height), panel1.Height);
            }
        }

        private void openImgBtn_Click(object sender, EventArgs e)
        {
            // 開新影像按鈕
            Debug.WriteLine("按下開啟影像按鈕");
            // currentRect
            currentRect = Rectangle.Empty;


            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = rootPath + "\\img"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgPath = openFileDialog1.FileName;
                oriImg = new Bitmap(imgPath);
                positionedImg = oriImg;
                resizePanel(oriImg, panel1);
                panel1.BackgroundImage = oriImg;
                panel1.BackgroundImageLayout = ImageLayout.Zoom;
                imgName.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("非 .bmp 檔案 ! 請重新選擇 !");
            }
        }

        private void saveImgBtn_Click(object sender, EventArgs e)
        {
            // 儲存影像按鈕
            Debug.WriteLine("按下儲存影像按鈕");
            int index = imgPath.LastIndexOf("\\");
            if (index != -1)
            {
                String savedImgPath = imgPath.Substring(0, index);
                Debug.WriteLine($"{savedImgPath}" + "\\" + newImgName.Text + ".bmp");
                new Bitmap(panel1.BackgroundImage).Save(savedImgPath + "\\" + newImgName.Text + ".bmp");
                MessageBox.Show("儲存影像成功 !");
            }
        }

        private async void grayBtn_Click(object sender, EventArgs e)
        {
            //  轉灰階按鈕
            if (panel1.BackgroundImage != null)
            {

            }
        }
        private async void blobDetectButton_Click(object sender, EventArgs e)
        {
            //  轉灰階按鈕
            if (panel1.BackgroundImage != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Mat binaryImg = imgToBinary.ConvertToBinary(positionedImage);
                Bitmap resultImg = blobSelector.SelectBlobWithAreaRatio(binaryImg, positionedImage);
                panel1.BackgroundImage = resultImg;

                setConsoleInfo();
                Functions.saveContoursToJson();
            }
        }
        private async void findTargetBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            if (panel1.BackgroundImage != null && targetImgPanel.BackgroundImage != null)
            {
                Mat targetImg = BitmapConverter.ToMat(new Bitmap(targetImgPanel.BackgroundImage));
                Mat panel1BGImage = BitmapConverter.ToMat(new Bitmap(panel1.BackgroundImage));
                positionedImg = Functions.findTarget(panel1BGImage, targetImg);
                resizePanel(positionedImg, panel1);
                panel1.BackgroundImage = positionedImg;
            }
        }
        private void blobDetect_binaryImg_Click(object sender, EventArgs e)
        {
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = BitmapConverter.ToBitmap(imgToBinary.ConvertToBinary(positionedImage));
                panel1.BackgroundImage = resultImg;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing && isMouseDown)
            {
                // 在畫布上繪製矩形的輪廓
                e.Graphics.DrawRectangle(Pens.Red, currentRect);
            }
        }
        private void rectangleBtn_Click(object sender, EventArgs e)
        {
            isDrawing = true;
            currentRect = new Rectangle(0, 0, 0, 0);
            panel1.Invalidate();
        }
        public void cropImgBtn_Click(object sender, EventArgs e)
        {
            if (!currentRect.IsEmpty)
            {
                positionedImg = Functions.CropBitmap(new Bitmap(panel1.BackgroundImage), currentRect);
                resizePanel(positionedImg, panel1);
                panel1.BackgroundImage = positionedImg;
            }
        }
        private void targetImgBtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = rootPath + "\\img\\targetImg"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgPath = openFileDialog1.FileName;
                targetImg = new Bitmap(imgPath);

                //resizePanel(targetImg, targetImgPanel);

                targetImgPanel.BackgroundImage = targetImg;
                targetImgPanel.BackgroundImageLayout = ImageLayout.Zoom;
                imgName.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("非 .bmp 檔案 ! 請重新選擇 !");
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isMouseDown = true;
                currentRect = new Rectangle(e.X, e.Y, 0, 0);
                panel1.Invalidate();
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1.BackgroundImage != null)
            {

                int mouseX = e.X;
                int mouseY = e.Y;

                // 獲取圖像的pixel座標
                int imageX = (int)((double)mouseX / panel1.Width * panel1.BackgroundImage.Width);
                int imageY = (int)((double)mouseY / panel1.Height * panel1.BackgroundImage.Height);

                // 獲取pixel value
                Color pixelColor = ((Bitmap)panel1.BackgroundImage).GetPixel(imageX, imageY);

                XValueTextBox.Text = imageX.ToString();
                YValueTextBox.Text = imageY.ToString();
                pixelValueTextBox.Text = pixelColor.R.ToString();
                if (isDrawing && isMouseDown)
                {
                    currentRect.Width = mouseX - currentRect.X;
                    currentRect.Height = mouseY - currentRect.Y;
                    panel1.Invalidate();
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
                isMouseDown = false;

                currentRect.X = (int)((double)currentRect.X / panel1.Width * panel1.BackgroundImage.Width);
                currentRect.Y = (int)((double)currentRect.Y / panel1.Width * panel1.BackgroundImage.Width);
                currentRect.Width = (int)((double)currentRect.Width / panel1.Width * panel1.BackgroundImage.Width);
                currentRect.Height = (int)((double)currentRect.Height / panel1.Width * panel1.BackgroundImage.Width);
            }
        }



        private void imgBinaryTabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = blobDetect_imgBinaryTabCtrl.SelectedIndex;
            imgToBinary.binaryWay = blobDetect_imgBinaryTabCtrl.TabPages[index].Text;
        }

        private void upperBoundScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            blobDetect_InRangeUpperBoundLabel.Text = blobDetect_InRangeUpperBoundScrollBar.Value.ToString();

            imgToBinary.inRangeUpperBound = blobDetect_InRangeUpperBoundScrollBar.Value;
            imgToBinary.binaryWay = "InRange";
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = BitmapConverter.ToBitmap(imgToBinary.ConvertToBinary(positionedImage));
                panel1.BackgroundImage = resultImg;
            }
        }

        private void lowerBoundScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            blobDetect_InRangeLowerBoundLabel.Text = blobDetect_InRangeLowerBoundScrollBar.Value.ToString();

            imgToBinary.inRangeLowerBound = blobDetect_InRangeLowerBoundScrollBar.Value;
            imgToBinary.binaryWay = "InRange";
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = BitmapConverter.ToBitmap(imgToBinary.ConvertToBinary(positionedImage));
                panel1.BackgroundImage = resultImg;
            }

        }

        private void solderBall_maxAreaBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_maxAreaLabel.Text = blob_maxAreaBar.Value.ToString();
            //blobDetectPara.blob_maxArea = blob_maxAreaBar.Value;

            blobSelector.blobMaxArea = blob_maxAreaBar.Value;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Mat binaryImg = imgToBinary.ConvertToBinary(positionedImage);
                Bitmap resultImg = blobSelector.SelectBlobWithAreaRatio(binaryImg, positionedImage);
                panel1.BackgroundImage = resultImg;
            }

        }

        private void solderBall_minRadiusBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_minRadiusLabel.Text = blob_minRadiusBar.Value.ToString();

            blobSelector.blobMinRadius = blob_minRadiusBar.Value;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Mat binaryImg = imgToBinary.ConvertToBinary(positionedImage);
                Bitmap resultImg = blobSelector.SelectBlobWithAreaRatio(binaryImg, positionedImage);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void solderBall_maxRadiusBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_maxRadiusLabel.Text = blob_maxRadiusBar.Value.ToString();
            //blobDetectPara.blob_maxRadius = blob_maxRadiusBar.Value;

            blobSelector.blobMaxRadius = blob_maxRadiusBar.Value;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Mat binaryImg = imgToBinary.ConvertToBinary(positionedImage);
                Bitmap resultImg = blobSelector.SelectBlobWithAreaRatio(binaryImg, positionedImage);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void elementImgBtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = rootPath + "\\img\\elementImg"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgPath = openFileDialog1.FileName;
                targetImg = new Bitmap(imgPath);


                elementImgPanel.BackgroundImage = targetImg;
                elementImgPanel.BackgroundImageLayout = ImageLayout.Zoom;
                imgName.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("非 .bmp 檔案 ! 請重新選擇 !");
            }
        }

        private void findElementBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            if (panel1.BackgroundImage != null && elementImgPanel.BackgroundImage != null)
            {
                Mat elementImg = BitmapConverter.ToMat(new Bitmap(elementImgPanel.BackgroundImage));
                Mat panel1BGImage = BitmapConverter.ToMat(new Bitmap(panel1.BackgroundImage));
                Bitmap elementsImg = Functions.findElement(panel1BGImage, elementImg, null);
                panel1.BackgroundImage = elementsImg;
            }
        }



        private void rotateBtn_test_Click(object sender, EventArgs e)
        {
            // 輸入旋轉角度
            Mat positionedImage = BitmapConverter.ToMat(positionedImg);
            Bitmap rotatedImg = Functions.rotateWithAngle(positionedImage, Double.Parse(rotateAngleTextBox.Text));
            positionedImg = rotatedImg;
            panel1.BackgroundImage = rotatedImg;
        }

        private void blobAreaRatioBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_AreaRatioLabel.Text = ((double)blobAreaRatioBar.Value / 100).ToString();

            blobSelector.blobAreaRatioThreshold = (double)blobAreaRatioBar.Value / 100;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Mat binaryImg = imgToBinary.ConvertToBinary(positionedImage);
                Bitmap resultImg = blobSelector.SelectBlobWithAreaRatio(binaryImg, positionedImage);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void DilateFlagCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            imgToBinary.dilateFlag = blobDetect_DilateFlagCheckBox.Checked;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = BitmapConverter.ToBitmap(imgToBinary.ConvertToBinary(positionedImage));
                panel1.BackgroundImage = resultImg;
            }
        }

        private void ErodeFlagCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //blobDetectPara.ErodeFlag = blobDetect_ErodeFlagCheckBox.Checked;

            imgToBinary.erodeFlag = blobDetect_ErodeFlagCheckBox.Checked;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = BitmapConverter.ToBitmap(imgToBinary.ConvertToBinary(positionedImage));
                panel1.BackgroundImage = resultImg;
            }
        }

        private void Dilate_Erode_Mask_Size_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //blobDetectPara.Dilate_Erode_Mask_Size = Convert.ToInt32(blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Value);

            imgToBinary.dilateErodeMaskSize = Convert.ToInt32(blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Value);
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = BitmapConverter.ToBitmap(imgToBinary.ConvertToBinary(positionedImage));
                panel1.BackgroundImage = resultImg;
            }
        }

        private void FindContoursWayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            blobSelector.findContoursWay = FindContoursWayComboBox.SelectedItem.ToString();
        }

        

        private void openParameterFileBtn_Click(object sender, EventArgs e)
        {
            // 開啟參數檔按鈕
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = rootPath + "\\parameter"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Contains(".ini"))
            {
                String iniFilePath = openFileDialog1.FileName;
                String parameterFileName = iniFilePath.Split("\\")[iniFilePath.Split("\\").Length - 1];
                openParameterFilePathLabel.Text = parameterFileName;

                loadParameterFile(iniFilePath);

            }
            else
            {
                MessageBox.Show("非 .ini 參數檔案 ! 請重新選擇 !");
            }
        }

        private void rotateAngleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void rotateImgBtn_Click(object sender, EventArgs e)
        {

            Bitmap resultImg = Functions.imgRotateWithSelectedBlob(BitmapConverter.ToMat(positionedImg));
            positionedImg = resultImg;
            panel1.BackgroundImage = resultImg;

        }

        private void rotateImg_InRangeUpperBoundScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            rotateImg_InRangeUpperBoundLabel.Text = rotateImg_InRangeUpperBoundScrollBar.Value.ToString();


            Bitmap resultImg = Functions.imgCanny(
                BitmapConverter.ToMat(positionedImg),
                rotateImg_InRangeUpperBoundScrollBar.Value,
                rotateImg_InRangeLowerBoundScrollBar.Value,
                rotateImg_DilateFlagCheckBox.Checked,
                rotateImg_ErodeFlagCheckBox.Checked,
                Convert.ToInt32(rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Value));

            panel1.BackgroundImage = resultImg;
        }

        private void rotateImg_InRangeLowerBoundScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            rotateImg_InRangeLowerBoundLabel.Text = rotateImg_InRangeLowerBoundScrollBar.Value.ToString();


            Bitmap resultImg = Functions.imgCanny(
                BitmapConverter.ToMat(positionedImg),
                rotateImg_InRangeUpperBoundScrollBar.Value,
                rotateImg_InRangeLowerBoundScrollBar.Value,
                rotateImg_DilateFlagCheckBox.Checked,
                rotateImg_ErodeFlagCheckBox.Checked,
                Convert.ToInt32(rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Value));

            panel1.BackgroundImage = resultImg;
        }

        private void CannyBtn_Click(object sender, EventArgs e)
        {
            Bitmap resultImg = Functions.imgCanny(
                BitmapConverter.ToMat(positionedImg),
                rotateImg_InRangeUpperBoundScrollBar.Value,
                rotateImg_InRangeLowerBoundScrollBar.Value,
                rotateImg_DilateFlagCheckBox.Checked,
                rotateImg_ErodeFlagCheckBox.Checked,
                Convert.ToInt32(rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Value));

            panel1.BackgroundImage = resultImg;
        }

        private void rotateImg_DilateFlagCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            Bitmap resultImg = Functions.imgCanny(
                BitmapConverter.ToMat(positionedImg),
                rotateImg_InRangeUpperBoundScrollBar.Value,
                rotateImg_InRangeLowerBoundScrollBar.Value,
                rotateImg_DilateFlagCheckBox.Checked,
                rotateImg_ErodeFlagCheckBox.Checked,
                Convert.ToInt32(rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Value));

            panel1.BackgroundImage = resultImg;
        }

        private void rotateImg_ErodeFlagCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            Bitmap resultImg = Functions.imgCanny(
                BitmapConverter.ToMat(positionedImg),
                rotateImg_InRangeUpperBoundScrollBar.Value,
                rotateImg_InRangeLowerBoundScrollBar.Value,
                rotateImg_DilateFlagCheckBox.Checked,
                rotateImg_ErodeFlagCheckBox.Checked,
                Convert.ToInt32(rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Value));

            panel1.BackgroundImage = resultImg;

        }

        private void rotateImg_Dilate_Erode_Mask_Size_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //blobDetectPara.Dilate_Erode_Mask_Size = Convert.ToInt32(blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Value);

            Bitmap resultImg = Functions.imgCanny(
                BitmapConverter.ToMat(positionedImg),
                rotateImg_InRangeUpperBoundScrollBar.Value,
                rotateImg_InRangeLowerBoundScrollBar.Value,
                rotateImg_DilateFlagCheckBox.Checked,
                rotateImg_ErodeFlagCheckBox.Checked,
                Convert.ToInt32(rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Value));

            panel1.BackgroundImage = resultImg;
        }

        private void rotateWayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void Dilate_Erode_Direction_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //blobDetectPara.Dilate_Erode_Direction = Dilate_Erode_Direction_ComboBox.SelectedItem.ToString();

            imgToBinary.dilateErodeDirection = Dilate_Erode_Direction_ComboBox.SelectedItem.ToString();
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = BitmapConverter.ToBitmap(imgToBinary.ConvertToBinary(positionedImage));
                panel1.BackgroundImage = resultImg;
            }
        }

        private void blobDetect_invertBinaryFlagCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //blobDetectPara.invertBinaryFlag = blobDetect_invertBinaryFlagCheckBox.Checked;

            imgToBinary.invertBinaryFlag = blobDetect_invertBinaryFlagCheckBox.Checked;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = BitmapConverter.ToBitmap(imgToBinary.ConvertToBinary(positionedImage));
                panel1.BackgroundImage = resultImg;
            }
        }
    }
}