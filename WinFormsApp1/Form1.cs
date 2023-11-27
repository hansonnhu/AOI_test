using System.Diagnostics;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
using System.IO;
//using functions;
//using https;
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

        // 各項參數檔
        // imgToBinary function 部分
        private String imgBinaryWay = "Otsu";
        private int InRangeUpperBound;
        private int InRangeLowerBound;
        private bool DilateFlag = false;
        private bool ErodeFlag = false;
        private int Dilate_Erode_Mask_Size = 1;
        // selectBlobWithAreaRatio function 部分
        private int blob_maxArea;
        private int blob_minRadius;
        private int blob_maxRadius;
        private double blobAreaRatio;
        private String findContoursWay;


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
            InRangeUpperBoundScrollBar.Value = InRangeUpperBound;
            InRangeUpperBoundLabel.Text = InRangeUpperBound.ToString();

            InRangeLowerBoundScrollBar.Value = InRangeLowerBound;
            InRangeLowerBoundLabel.Text = InRangeLowerBound.ToString();

            blob_maxAreaBar.Value = blob_maxArea;
            blob_maxAreaLabel.Text = blob_maxArea.ToString();

            blob_minRadiusBar.Value = blob_minRadius;
            blob_minRadiusLabel.Text = blob_minRadius.ToString();

            blob_maxRadiusBar.Value = blob_maxRadius;
            blob_maxRadiusLabel.Text = blob_maxRadius.ToString();

            blobAreaRatioBar.Value = Convert.ToInt32(blobAreaRatio * 100);
            blob_AreaRatioLabel.Text = Convert.ToInt32(blobAreaRatio * 100).ToString();

            FindContoursWayComboBox.SelectedItem = FindContoursWayComboBox.Items.Cast<dynamic>().FirstOrDefault(x => x == findContoursWay);


            DilateFlagCheckBox.Checked = DilateFlag;
            ErodeFlagCheckBox.Checked = ErodeFlag;
            Dilate_Erode_Mask_Size_NumericUpDown.Value = Dilate_Erode_Mask_Size;


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

        public void loadParameterFile(String iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                var parser = new FileIniDataParser();
                consoleLabel.Text = "已讀取參數檔 : " + "parameter1.ini" + "\n";
                var data = parser.ReadFile(iniFilePath);
                imgBinaryWay = data["parameter"]["imgBinaryWay"];
                InRangeUpperBound = int.Parse(data["parameter"]["InRangeUpperBound"]);
                InRangeLowerBound = int.Parse(data["parameter"]["InRangeLowerBound"]);
                DilateFlag = int.Parse(data["parameter"]["DilateFlag"]) == 1 ? true : false;
                ErodeFlag = int.Parse(data["parameter"]["ErodeFlag"]) == 1 ? true : false;
                Dilate_Erode_Mask_Size = int.Parse(data["parameter"]["Dilate_Erode_Mask_Size"]);
                blob_maxArea = int.Parse(data["parameter"]["blob_maxArea"]);
                blob_minRadius = int.Parse(data["parameter"]["blob_minRadius"]);
                blob_maxRadius = int.Parse(data["parameter"]["blob_maxRadius"]);
                blobAreaRatio = (double)int.Parse(data["parameter"]["blobAreaRatio"]) / 100;
                findContoursWay = data["parameter"]["findContoursWay"];
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
                Bitmap resultImg = Functions.selectBlobWithAreaRatio(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBound,
                    InRangeLowerBound,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size,
                    blob_maxArea,
                    blob_minRadius,
                    blob_maxRadius,
                    blobAreaRatio,
                    findContoursWay);
                panel1.BackgroundImage = resultImg;

                // console 當前參數
                consoleLabel.Text = "";// 先清空
                consoleLabel.Text += "當前參數\n";

                consoleLabel.Text += "二值化部分\n";
                consoleLabel.Text += "imgBinaryWay : " + imgBinaryWay + "\n";
                consoleLabel.Text += "InRangeUpperBound : " + InRangeUpperBound + "\n";
                consoleLabel.Text += "InRangeLowerBound : " + InRangeLowerBound + "\n";
                consoleLabel.Text += "DilateFlag : " + DilateFlag + "\n";
                consoleLabel.Text += "ErodeFlag : " + ErodeFlag + "\n";
                consoleLabel.Text += "Dilate_Erode_Mask_Size : " + Dilate_Erode_Mask_Size + "\n";

                consoleLabel.Text += "blob部分\n";
                consoleLabel.Text += "blob_maxArea : " + blob_maxArea + "\n";
                consoleLabel.Text += "blob_minRadius : " + blob_minRadius + "\n";
                consoleLabel.Text += "blob_maxRadius : " + blob_maxRadius + "\n";
                consoleLabel.Text += "blobAreaRatio : " + blobAreaRatio + "\n";
                consoleLabel.Text += "findContoursWay : " + findContoursWay + "\n";

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
        private void binaryImg_Click(object sender, EventArgs e)
        {
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBoundScrollBar.Value,
                    InRangeLowerBoundScrollBar.Value,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size);
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

        private void ImgBinComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imgBinaryWay == "Otsu")
            {

            }
            else if (imgBinaryWay == "InRange")
            {

            }
        }

        private void imgBinaryTabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = imgBinaryTabCtrl.SelectedIndex;
            imgBinaryWay = imgBinaryTabCtrl.TabPages[index].Text;
        }

        private void upperBoundScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            InRangeUpperBoundLabel.Text = InRangeUpperBoundScrollBar.Value.ToString();
            InRangeUpperBound = InRangeUpperBoundScrollBar.Value;
            imgBinaryWay = "InRange";
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBoundScrollBar.Value,
                    InRangeLowerBoundScrollBar.Value,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void lowerBoundScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            InRangeLowerBoundLabel.Text = InRangeLowerBoundScrollBar.Value.ToString();
            InRangeLowerBound = InRangeLowerBoundScrollBar.Value;
            imgBinaryWay = "InRange";
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBoundScrollBar.Value,
                    InRangeLowerBoundScrollBar.Value,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size);
                panel1.BackgroundImage = resultImg;
            }

        }

        private void solderBall_maxAreaBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_maxAreaLabel.Text = blob_maxAreaBar.Value.ToString();
            blob_maxArea = blob_maxAreaBar.Value;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.selectBlobWithAreaRatio(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBound,
                    InRangeLowerBound,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size,
                    blob_maxArea,
                    blob_minRadius,
                    blob_maxRadius,
                    blobAreaRatio,
                    findContoursWay);
                panel1.BackgroundImage = resultImg;
            }

        }

        private void solderBall_minRadiusBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_minRadiusLabel.Text = blob_minRadiusBar.Value.ToString();
            blob_minRadius = blob_minRadiusBar.Value;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.selectBlobWithAreaRatio(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBound,
                    InRangeLowerBound,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size,
                    blob_maxArea,
                    blob_minRadius,
                    blob_maxRadius,
                    blobAreaRatio,
                    findContoursWay);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void solderBall_maxRadiusBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_maxRadiusLabel.Text = blob_maxRadiusBar.Value.ToString();
            blob_maxRadius = blob_maxRadiusBar.Value;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.selectBlobWithAreaRatio(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBound,
                    InRangeLowerBound,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size,
                    blob_maxArea,
                    blob_minRadius,
                    blob_maxRadius,
                    blobAreaRatio,
                    findContoursWay);
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
                //resizePanel(positionedImg, panel1);
                panel1.BackgroundImage = elementsImg;
            }
        }



        private void rotateBtn_Click(object sender, EventArgs e)
        {
            // 輸入旋轉角度
            Mat positionedImage = BitmapConverter.ToMat(positionedImg);
            Bitmap rotatedImg = Functions.rotateWithAngle(positionedImage, Double.Parse(rotateAngleTextBox.Text));
            resizePanel(rotatedImg, panel1);
            panel1.BackgroundImage = rotatedImg;
        }

        private void blobAreaRatioBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_AreaRatioLabel.Text = blobAreaRatioBar.Value.ToString();
            blobAreaRatio = (double)blobAreaRatioBar.Value / 100;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.selectBlobWithAreaRatio(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBound,
                    InRangeLowerBound,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size,
                    blob_maxArea,
                    blob_minRadius,
                    blob_maxRadius,
                    blobAreaRatio,
                    findContoursWay);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void DilateFlagCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DilateFlag = DilateFlagCheckBox.Checked;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBoundScrollBar.Value,
                    InRangeLowerBoundScrollBar.Value,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void ErodeFlagCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ErodeFlag = ErodeFlagCheckBox.Checked;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBoundScrollBar.Value,
                    InRangeLowerBoundScrollBar.Value,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void Dilate_Erode_Mask_Size_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Dilate_Erode_Mask_Size = Convert.ToInt32(Dilate_Erode_Mask_Size_NumericUpDown.Value);
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    imgBinaryWay,
                    InRangeUpperBoundScrollBar.Value,
                    InRangeLowerBoundScrollBar.Value,
                    DilateFlag,
                    ErodeFlag,
                    Dilate_Erode_Mask_Size);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void FindContoursWayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            findContoursWay = FindContoursWayComboBox.SelectedItem.ToString();
        }

        private void saveParameterBtn_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            var data = new IniData();
            data["parameter"]["imgBinaryWay"] = imgBinaryWay;
            data["parameter"]["InRangeUpperBound"] = InRangeUpperBound.ToString();
            data["parameter"]["InRangeLowerBound"] = InRangeLowerBound.ToString();
            data["parameter"]["DilateFlag"] = DilateFlag ? "1" : "0";
            data["parameter"]["ErodeFlag"] = ErodeFlag ? "1" : "0";
            data["parameter"]["Dilate_Erode_Mask_Size"] = Dilate_Erode_Mask_Size.ToString();
            data["parameter"]["blob_maxArea"] = blob_maxArea.ToString();
            data["parameter"]["blob_minRadius"] = blob_minRadius.ToString();
            data["parameter"]["blob_maxRadius"] = blob_maxRadius.ToString();
            data["parameter"]["blobAreaRatio"] = ((int)(blobAreaRatio * 100)).ToString();
            data["parameter"]["findContoursWay"] = findContoursWay;

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

        private void openParameterFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = rootPath + "\\parameter"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Contains(".ini"))
            {
                String iniFilePath = openFileDialog1.FileName;
                openParameterFilePathLabel.Text = iniFilePath;
                openParameterFilePathLabel.Text = iniFilePath.Split("\\")[iniFilePath.Split("\\").Length - 1];

            }
            else
            {
                MessageBox.Show("非 .ini 參數檔案 ! 請重新選擇 !");
            }
        }

        private void rotateAngleTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}