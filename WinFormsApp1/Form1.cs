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

        // 各項 function 參數檔
        blobDetectParameter blobDetectPara = new blobDetectParameter();

        // imgToBinary function 部分
        //private String imgBinaryWay = "Otsu";
        //private int InRangeUpperBound;
        //private int InRangeLowerBound;
        //private bool DilateFlag = false;
        //private bool ErodeFlag = false;
        //private int Dilate_Erode_Mask_Size = 1;
        //// selectBlobWithAreaRatio function 部分
        //private int blob_maxArea;
        //private int blob_minRadius;
        //private int blob_maxRadius;
        //private double blobAreaRatio;
        //private String findContoursWay;


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
            consoleLabel.Text += "imgBinaryWay : " + blobDetectPara.imgBinaryWay + "\n";
            consoleLabel.Text += "InRangeUpperBound : " + blobDetectPara.InRangeUpperBound + "\n";
            consoleLabel.Text += "InRangeLowerBound : " + blobDetectPara.InRangeLowerBound + "\n";
            consoleLabel.Text += "DilateFlag : " + blobDetectPara.DilateFlag + "\n";
            consoleLabel.Text += "ErodeFlag : " + blobDetectPara.ErodeFlag + "\n";
            consoleLabel.Text += "Dilate_Erode_Mask_Size : " + blobDetectPara.Dilate_Erode_Mask_Size + "\n";
            consoleLabel.Text += "blob_maxArea : " + blobDetectPara.blob_maxArea + "\n";
            consoleLabel.Text += "blob_minRadius : " + blobDetectPara.blob_minRadius + "\n";
            consoleLabel.Text += "blob_maxRadius : " + blobDetectPara.blob_maxRadius + "\n";
            consoleLabel.Text += "blobAreaRatio : " + blobDetectPara.blobAreaRatio + "\n";
            consoleLabel.Text += "findContoursWay : " + blobDetectPara.findContoursWay + "\n";
        }

        public class ImgToBinaryParameter
        {
            public string imgBinaryWay;
            public int InRangeUpperBound;
            public int InRangeLowerBound;
            public bool DilateFlag;
            public bool ErodeFlag;
            public int Dilate_Erode_Mask_Size;

            public ImgToBinaryParameter()
            {
                imgBinaryWay = "";
                InRangeUpperBound = 0;
                InRangeLowerBound = 0;
                DilateFlag = true;
                ErodeFlag = true;
                Dilate_Erode_Mask_Size = 0;
            }
        }

        public class blobDetectParameter : ImgToBinaryParameter
        {
            // blobDecterParameter 的參數 class
            public int blob_maxArea;
            public int blob_minRadius;
            public int blob_maxRadius;
            public double blobAreaRatio;
            public String findContoursWay;


            public blobDetectParameter()
            {
                blob_maxArea = 0;
                blob_minRadius = 0;
                blob_maxRadius = 0;
                blobAreaRatio = 0;
                findContoursWay = "";
                imgBinaryWay = "";
                InRangeUpperBound = 0;
                InRangeLowerBound = 0;
                DilateFlag = true;
                ErodeFlag = true;
                Dilate_Erode_Mask_Size = 0;
            }
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
                blobDetectPara.imgBinaryWay = data["blobDetect"]["imgBinaryWay"];
                blobDetectPara.InRangeUpperBound = int.Parse(data["blobDetect"]["InRangeUpperBound"]);
                blobDetectPara.InRangeLowerBound = int.Parse(data["blobDetect"]["InRangeLowerBound"]);
                blobDetectPara.DilateFlag = int.Parse(data["blobDetect"]["DilateFlag"]) == 1 ? true : false;
                blobDetectPara.ErodeFlag = int.Parse(data["blobDetect"]["ErodeFlag"]) == 1 ? true : false;
                blobDetectPara.Dilate_Erode_Mask_Size = int.Parse(data["blobDetect"]["Dilate_Erode_Mask_Size"]);
                blobDetectPara.blob_maxArea = int.Parse(data["blobDetect"]["blob_maxArea"]);
                blobDetectPara.blob_minRadius = int.Parse(data["blobDetect"]["blob_minRadius"]);
                blobDetectPara.blob_maxRadius = int.Parse(data["blobDetect"]["blob_maxRadius"]);
                blobDetectPara.blobAreaRatio = (double)int.Parse(data["blobDetect"]["blobAreaRatio"]) / 100;
                blobDetectPara.findContoursWay = data["blobDetect"]["findContoursWay"];


                // 將 blobDetect 數值更新於介面
                blobDetect_InRangeUpperBoundScrollBar.Value = blobDetectPara.InRangeUpperBound;
                blobDetect_InRangeUpperBoundLabel.Text = blobDetectPara.InRangeUpperBound.ToString();

                blobDetect_InRangeLowerBoundScrollBar.Value = blobDetectPara.InRangeLowerBound;
                blobDetect_InRangeLowerBoundLabel.Text = blobDetectPara.InRangeLowerBound.ToString();

                blob_maxAreaBar.Value = blobDetectPara.blob_maxArea;
                blob_maxAreaLabel.Text = blobDetectPara.blob_maxArea.ToString();

                blob_minRadiusBar.Value = blobDetectPara.blob_minRadius;
                blob_minRadiusLabel.Text = blobDetectPara.blob_minRadius.ToString();

                blob_maxRadiusBar.Value = blobDetectPara.blob_maxRadius;
                blob_maxRadiusLabel.Text = blobDetectPara.blob_maxRadius.ToString();

                blobAreaRatioBar.Value = Convert.ToInt32(blobDetectPara.blobAreaRatio * 100);
                blob_AreaRatioLabel.Text = blobDetectPara.blobAreaRatio.ToString();

                FindContoursWayComboBox.SelectedItem = FindContoursWayComboBox.Items.Cast<dynamic>().FirstOrDefault(x => x == blobDetectPara.findContoursWay);

                blobDetect_DilateFlagCheckBox.Checked = blobDetectPara.ErodeFlag;
                blobDetect_ErodeFlagCheckBox.Checked = blobDetectPara.ErodeFlag;
                blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Value = blobDetectPara.Dilate_Erode_Mask_Size;

                setConsoleInfo();
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
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size,
                    blobDetectPara.blob_maxArea,
                    blobDetectPara.blob_minRadius,
                    blobDetectPara.blob_maxRadius,
                    blobDetectPara.blobAreaRatio,
                    blobDetectPara.findContoursWay);
                panel1.BackgroundImage = resultImg;

                setConsoleInfo();

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
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size);
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
            if (blobDetectPara.imgBinaryWay == "Otsu")
            {

            }
            else if (blobDetectPara.imgBinaryWay == "InRange")
            {

            }
        }

        private void imgBinaryTabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = blobDetect_imgBinaryTabCtrl.SelectedIndex;
            blobDetectPara.imgBinaryWay = blobDetect_imgBinaryTabCtrl.TabPages[index].Text;
        }

        private void upperBoundScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            blobDetect_InRangeUpperBoundLabel.Text = blobDetect_InRangeUpperBoundScrollBar.Value.ToString();
            blobDetectPara.InRangeUpperBound = blobDetect_InRangeUpperBoundScrollBar.Value;
            blobDetectPara.imgBinaryWay = "InRange";
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void lowerBoundScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            blobDetect_InRangeLowerBoundLabel.Text = blobDetect_InRangeLowerBoundScrollBar.Value.ToString();
            blobDetectPara.InRangeLowerBound = blobDetect_InRangeLowerBoundScrollBar.Value;
            blobDetectPara.imgBinaryWay = "InRange";
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size);
                panel1.BackgroundImage = resultImg;
            }

        }

        private void solderBall_maxAreaBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_maxAreaLabel.Text = blob_maxAreaBar.Value.ToString();
            blobDetectPara.blob_maxArea = blob_maxAreaBar.Value;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.selectBlobWithAreaRatio(positionedImage,
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size,
                    blobDetectPara.blob_maxArea,
                    blobDetectPara.blob_minRadius,
                    blobDetectPara.blob_maxRadius,
                    blobDetectPara.blobAreaRatio,
                    blobDetectPara.findContoursWay);
                panel1.BackgroundImage = resultImg;
            }

        }

        private void solderBall_minRadiusBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_minRadiusLabel.Text = blob_minRadiusBar.Value.ToString();
            blobDetectPara.blob_minRadius = blob_minRadiusBar.Value;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.selectBlobWithAreaRatio(positionedImage,
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size,
                    blobDetectPara.blob_maxArea,
                    blobDetectPara.blob_minRadius,
                    blobDetectPara.blob_maxRadius,
                    blobDetectPara.blobAreaRatio,
                    blobDetectPara.findContoursWay);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void solderBall_maxRadiusBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_maxRadiusLabel.Text = blob_maxRadiusBar.Value.ToString();
            blobDetectPara.blob_maxRadius = blob_maxRadiusBar.Value;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.selectBlobWithAreaRatio(positionedImage,
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size,
                    blobDetectPara.blob_maxArea,
                    blobDetectPara.blob_minRadius,
                    blobDetectPara.blob_maxRadius,
                    blobDetectPara.blobAreaRatio,
                    blobDetectPara.findContoursWay);
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



        private void rotateBtn_test_Click(object sender, EventArgs e)
        {
            // 輸入旋轉角度
            Mat positionedImage = BitmapConverter.ToMat(positionedImg);
            Bitmap rotatedImg = Functions.rotateWithAngle(positionedImage, Double.Parse(rotateAngleTextBox.Text));
            positionedImg = rotatedImg;
            //resizePanel(rotatedImg, panel1);
            panel1.BackgroundImage = rotatedImg;
        }

        private void blobAreaRatioBar_Scroll(object sender, ScrollEventArgs e)
        {
            blob_AreaRatioLabel.Text = ((double)blobAreaRatioBar.Value / 100).ToString();
            blobDetectPara.blobAreaRatio = (double)blobAreaRatioBar.Value / 100;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.selectBlobWithAreaRatio(positionedImage,
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size,
                    blobDetectPara.blob_maxArea,
                    blobDetectPara.blob_minRadius,
                    blobDetectPara.blob_maxRadius,
                    blobDetectPara.blobAreaRatio,
                    blobDetectPara.findContoursWay);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void DilateFlagCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            blobDetectPara.DilateFlag = blobDetect_DilateFlagCheckBox.Checked;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void ErodeFlagCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            blobDetectPara.ErodeFlag = blobDetect_ErodeFlagCheckBox.Checked;
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void Dilate_Erode_Mask_Size_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            blobDetectPara.Dilate_Erode_Mask_Size = Convert.ToInt32(blobDetect_Dilate_Erode_Mask_Size_NumericUpDown.Value);
            if (positionedImg != null)
            {
                Mat positionedImage = BitmapConverter.ToMat(positionedImg);
                Bitmap resultImg = Functions.imgToBinary(positionedImage,
                    blobDetectPara.imgBinaryWay,
                    blobDetectPara.InRangeUpperBound,
                    blobDetectPara.InRangeLowerBound,
                    blobDetectPara.DilateFlag,
                    blobDetectPara.ErodeFlag,
                    blobDetectPara.Dilate_Erode_Mask_Size);
                panel1.BackgroundImage = resultImg;
            }
        }

        private void FindContoursWayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            blobDetectPara.findContoursWay = FindContoursWayComboBox.SelectedItem.ToString();
        }

        private void saveParameterBtn_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            var data = new IniData();
            data["blobDetect"]["imgBinaryWay"] = blobDetectPara.imgBinaryWay;
            data["blobDetect"]["InRangeUpperBound"] = blobDetectPara.InRangeUpperBound.ToString();
            data["blobDetect"]["InRangeLowerBound"] = blobDetectPara.InRangeLowerBound.ToString();
            data["blobDetect"]["DilateFlag"] = blobDetectPara.DilateFlag ? "1" : "0";
            data["blobDetect"]["ErodeFlag"] = blobDetectPara.ErodeFlag ? "1" : "0";
            data["blobDetect"]["Dilate_Erode_Mask_Size"] = blobDetectPara.Dilate_Erode_Mask_Size.ToString();
            data["blobDetect"]["blob_maxArea"] = blobDetectPara.blob_maxArea.ToString();
            data["blobDetect"]["blob_minRadius"] = blobDetectPara.blob_minRadius.ToString();
            data["blobDetect"]["blob_maxRadius"] = blobDetectPara.blob_maxRadius.ToString();
            data["blobDetect"]["blobAreaRatio"] = ((int)(blobDetectPara.blobAreaRatio * 100)).ToString();
            data["blobDetect"]["findContoursWay"] = blobDetectPara.findContoursWay;

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
            // 開啟參數檔按鈕
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = rootPath + "\\parameter"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Contains(".ini"))
            {
                String iniFilePath = openFileDialog1.FileName;
                //openParameterFilePathLabel.Text = iniFilePath;
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
            Bitmap resultImg = Functions.imgRotate(
                BitmapConverter.ToMat(positionedImg),
                BitmapConverter.ToMat(targetImg),
                rotateImg_InRangeUpperBoundScrollBar.Value,
                rotateImg_InRangeLowerBoundScrollBar.Value,
                rotateImg_DilateFlagCheckBox.Checked,
                rotateImg_ErodeFlagCheckBox.Checked,
                Convert.ToInt32(rotateImg_Dilate_Erode_Mask_Size_NumericUpDown.Value));
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
    }
}