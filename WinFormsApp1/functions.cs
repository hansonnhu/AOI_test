// Functions.cs
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;
using System;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;


public class GlobalVariables
{
    //public static List<int> removeCntIndex = new List<int>(); // 紀錄要刪除的輪廓
    public static OpenCvSharp.Point[][] targetContours;
}


public class Functions
{
    public static String rootPath = System.Environment.CurrentDirectory.ToString().Split("\\WinFormsApp1\\bin\\")[0];// 跟目錄 path 設定;



    public static Bitmap CropBitmap(Bitmap source, Rectangle cropArea)
    {
        // 截圖
        // 確保裁剪區域在圖像範圍內
        cropArea.Intersect(new Rectangle(0, 0, source.Width, source.Height));

        // 創建新的 Bitmap 並從原始圖像中複製指定區域
        try
        {
            Bitmap croppedBitmap = new Bitmap(cropArea.Width, cropArea.Height);
            using (Graphics g = Graphics.FromImage(croppedBitmap))
            {
                g.DrawImage(source, new Rectangle(0, 0, cropArea.Width, cropArea.Height),
                            cropArea, GraphicsUnit.Pixel);
            }
            return croppedBitmap;
        }
        catch
        {
            return source;
        }
    }

    public static Mat makeMask(Mat firstBinaImg, Mat secondBinaryImg)
    {
        // 以 or 運算製作 mask
        Mat result = new Mat();
        Cv2.BitwiseOr(firstBinaImg, secondBinaryImg, result);
        return result;
    }

    static int CountPixelsInContour(Mat image, OpenCvSharp.Point[] contour)
    {
        Mat mask = new Mat(image.Size(), MatType.CV_8UC1, Scalar.Black);
        Cv2.DrawContours(mask, new List<OpenCvSharp.Point[]> { contour }, -1, Scalar.White, -1);
        int count = Cv2.CountNonZero(mask);
        mask.Dispose();
        return count;
    }

    // 找尋第一個 blob 輪廓中，X值最小的點，與Y值最大的點
    public static (OpenCvSharp.Point topLeft, OpenCvSharp.Point bottomLeft, OpenCvSharp.Point topRight, OpenCvSharp.Point bottomRight) FindFourTopPoints(OpenCvSharp.Point[] contour)
    {
        if (contour == null || contour.Length == 0)
            throw new ArgumentException("Invalid contour");

        // 初始化點
        OpenCvSharp.Point topLeft = contour[0];
        OpenCvSharp.Point topRight = contour[0];
        OpenCvSharp.Point bottomLeft = contour[0];
        OpenCvSharp.Point bottomRight = contour[0];

        foreach (var point in contour)
        {
            // 找最左上的點
            if ((point.X + point.Y) < (topLeft.X + topLeft.Y))
                topLeft = point;

            // 找最右上的點
            if ((point.X - point.Y) > (topRight.X - topRight.Y))
                topRight = point;

            // 找最左下的點
            if ((point.X - point.Y) < (bottomLeft.X - bottomLeft.Y))
                bottomLeft = point;

            // 找最右下的點
            if ((point.X + point.Y) > (bottomRight.X + bottomRight.Y))
                bottomRight = point;
        }
        Debug.WriteLine(topLeft);
        Debug.WriteLine(bottomLeft);

        return (topLeft, bottomLeft, topRight, bottomRight);
    }

    // 找尋所有 blobs 的外接圓圓心的最左上角以及最右下角圓心點
    public static (OpenCvSharp.Point topLeft, OpenCvSharp.Point bottomLeft) FindTwoCircleCenter(OpenCvSharp.Point[][] contours)
    {
        if (contours == null || contours.Length == 0)
            throw new ArgumentException("Invalid contour");

        // 初始化點
        OpenCvSharp.Point topLeftCircleCenter = contours[0][0];
        OpenCvSharp.Point bottomLeftCircleCenter = contours[0][0];

        foreach (OpenCvSharp.Point[] contour in contours)
        {
            Cv2.MinEnclosingCircle(contour, out Point2f center, out float radius);
            // 找最左上的點
            if ((center.X + center.Y) < (topLeftCircleCenter.X + topLeftCircleCenter.Y))
            {
                topLeftCircleCenter.X = Convert.ToInt32(center.X);
                topLeftCircleCenter.Y = Convert.ToInt32(center.Y);
            }
            // 找最左下的點
            if ((center.X - center.Y) < (bottomLeftCircleCenter.X - bottomLeftCircleCenter.Y))
            {
                bottomLeftCircleCenter.X = Convert.ToInt32(center.X);
                bottomLeftCircleCenter.Y = Convert.ToInt32(center.Y);
            }
        }
        return (topLeftCircleCenter, bottomLeftCircleCenter);

    }

    public static Bitmap imgRotateWithSelectedBlob(Mat img)
    {
        // 讀取 blob 抓取的物件
        string json = File.ReadAllText(rootPath + "\\parameter\\contours.json");
        OpenCvSharp.Point[][] Contours = JsonConvert.DeserializeObject<OpenCvSharp.Point[][]>(json);

        #region Cv2.MinAreaRect(contours) 實作
        double alsntDegrees = 0;

        IEnumerable<OpenCvSharp.Point> tempPoints = Contours.SelectMany(contour => contour);
        alsntDegrees = Cv2.MinAreaRect(tempPoints).Angle;

        if (alsntDegrees > 45)
        {
            {
                alsntDegrees = alsntDegrees - 90;
            }
        }
        Debug.WriteLine(alsntDegrees);
        #endregion

        return rotateWithAngle(img, alsntDegrees);

    }


    public static Bitmap rotateWithAngle(Mat src, double angle)
    {
        // 依角度旋轉圖片
        Mat dst = new Mat();
        float radian = (float)(angle / 180.0 * Cv2.PI);

        //填充圖像
        int maxBorder = (int)(Math.Max(src.Cols, src.Rows) * 1.414); //即为sqrt(2)*max
        int dx = (maxBorder - src.Cols) / 2;
        int dy = (maxBorder - src.Rows) / 2;
        Cv2.CopyMakeBorder(src, dst, dy, dy, dx, dx, BorderTypes.Constant);

        //旋轉
        Point2f center = new Point2f((float)(dst.Cols / 2), (float)(dst.Rows / 2));
        Mat affine_matrix = Cv2.GetRotationMatrix2D(center, angle, 1.0);//求得旋转矩阵
        Cv2.WarpAffine(dst, dst, affine_matrix, dst.Size());

        //計算旋轉之後包含圖像的最大矩形
        float sinVal = (float)Math.Abs(Math.Sin(radian));
        float cosVal = (float)Math.Abs(Math.Cos(radian));
        OpenCvSharp.Size targetSize = new OpenCvSharp.Size((int)(src.Cols * cosVal + src.Rows * sinVal),
                 (int)(src.Cols * sinVal + src.Rows * cosVal));

        //剪掉多餘邊框
        int x = (dst.Cols - targetSize.Width) / 2;
        int y = (dst.Rows - targetSize.Height) / 2;
        Rect rect = new Rect(x, y, targetSize.Width, targetSize.Height);

        return BitmapConverter.ToBitmap(new Mat(dst, rect));
    }


    public static Bitmap selectBlobWithAreaRatio(
        Mat img,
        String binaryWay,
        int InRangeUpperBound,
        int InRangeLowerBound,
        bool DilateFlag,
        bool ErodeFlag,
        int Dilate_Erode_Mask_Size,
        int solderBalls_maxArea,
        int solderBalls_minRadius,
        int solderBalls_maxRadius,
        double blobAreaRatioThreshold,
        String findContoursWay,
        String Dilate_Erode_Direction)
    {
        // 分析blob

        Console.WriteLine("This is selectBlobWithAreaRatio Function");
        Mat img_binary = new Mat();
        img_binary = BitmapConverter.ToMat(imgToBinary(img,
            binaryWay,
            InRangeUpperBound,
            InRangeLowerBound,
            DilateFlag,
            ErodeFlag,
            Dilate_Erode_Mask_Size,
            Dilate_Erode_Direction));

        // 找到輪廓
        OpenCvSharp.Point[][] contours;
        HierarchyIndex[] hierarchy;
        GlobalVariables.targetContours = new OpenCvSharp.Point[][] { };

        OpenCvSharp.Point[][] Contours = { };
        if (findContoursWay == "External")
        {
            Cv2.FindContours(img_binary, out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            Contours = contours;
        }

        else if (findContoursWay == "List")
        {
            Cv2.FindContours(img_binary, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);
            Contours = contours;
        }

        foreach (var cnt in Contours)
        {
            Cv2.MinEnclosingCircle(cnt, out Point2f center, out float radius);
            if (radius < solderBalls_minRadius || radius > solderBalls_maxRadius)
            {
                continue;
            }

            //int blobArea = CountPixelsInContour(img_binary, cnt);
            double blobArea = Cv2.ContourArea(cnt);
            double area_ratio = blobArea / (Math.Pow(radius, 2) * 3.14159);

            // blob 面積占比大於 blobAreaRatioThreshold 才檢出
            if (area_ratio < blobAreaRatioThreshold)
            {
                continue;
            }

            // 將篩選出來的 Blob 參數儲存
            GlobalVariables.targetContours = GlobalVariables.targetContours.Concat(new[] { cnt }).ToArray();

            // 繪製輪廓
            // 創建一個空的四通道影像
            Mat colorImg = new Mat(img.Rows, img.Cols, MatType.CV_8UC4);
            // 將灰度影像轉換為四通道影像
            try
            {
                // 將灰階轉為彩色
                Cv2.CvtColor(img, img, ColorConversionCodes.GRAY2RGBA);
            }
            catch
            {
                // 本來就是彩色
            }

            var oneContour = cnt;
            Cv2.DrawContours(img, new[] { oneContour }, -1, new Scalar(76, 153, 0, 255), 2);

            int radiusInt = (int)radius;
            if (blobArea > solderBalls_maxArea)
                Cv2.Circle(img, Convert.ToInt32(center.X), Convert.ToInt32(center.Y), radiusInt, new Scalar(0, 0, 255, 255), 2);
            else
                Cv2.Circle(img, Convert.ToInt32(center.X), Convert.ToInt32(center.Y), radiusInt, new Scalar(0, 255, 0, 255), 2);
        }
        return BitmapConverter.ToBitmap(img);
    }

    // 儲存 Contours 物件為 Json
    public static void saveContoursToJson()
    {
        // 保留需要的輪廓，並以json儲存於電腦

        string contoursJson = JsonConvert.SerializeObject(GlobalVariables.targetContours);
        File.WriteAllText(rootPath + "\\parameter\\contours.json", contoursJson);
    }

    public static Bitmap findTarget(Mat img, Mat targetImg)
    {
        // 最一開始找尋影像中的目標，用以定位及之後的 rotate 
        Console.WriteLine("This is findTarget Function");

        Mat result = new Mat();

        Mat grayTemplateImage = new Mat();
        Cv2.CvtColor(targetImg, grayTemplateImage, ColorConversionCodes.BGR2GRAY);
        Mat grayimg = new Mat();
        Cv2.CvtColor(img, grayimg, ColorConversionCodes.BGR2GRAY);

        // 將 Bitmap 轉換為 Mat
        Cv2.MatchTemplate(grayimg, grayTemplateImage, result, TemplateMatchModes.CCoeffNormed);
        //Cv2.Normalize(result, result, -1, 1, NormTypes.MinMax, -1);


        // 取得匹配位置中的最大值和對應位置
        double minValue, maxValue;

        double threshold = 0.7;

        OpenCvSharp.Point minLocation, maxLocation;
        Cv2.MinMaxLoc(result, out minValue, out maxValue, out minLocation, out maxLocation);



        Bitmap tempBmp;
        tempBmp = CropBitmap(BitmapConverter.ToBitmap(img), new Rectangle(maxLocation.X, maxLocation.Y, targetImg.Width, targetImg.Height));

        //tempBmp = rotateWithAngle(BitmapConverter.ToMat(tempBmp), 3.5);
        return tempBmp;
    }

    public static Bitmap findElement(Mat img, Mat elementImg, Mat mask)
    {
        // 以 pattern match 找尋影像中所需要的 element
        Console.WriteLine("This is findElement Function");

        Mat result = new Mat();

        // 影像轉灰階
        Mat grayElementImage = new Mat();
        Cv2.CvtColor(elementImg, grayElementImage, ColorConversionCodes.BGR2GRAY);
        Mat grayimg = new Mat();
        Cv2.CvtColor(img, grayimg, ColorConversionCodes.BGR2GRAY);

        // 模板比對
        Cv2.MatchTemplate(grayimg, grayElementImage, result, TemplateMatchModes.CCoeffNormed, mask);


        // 取得匹配位置中的最大值和對應位置
        double minValue, maxValue;
        double threshold = 0.01;
        OpenCvSharp.Point minLocation, maxLocation;
        Cv2.MinMaxLoc(result, out minValue, out maxValue, out minLocation, out maxLocation);


        //設定閾值，畫出 element 矩形框
        if (maxValue > threshold)
        {
            OpenCvSharp.Point tempPoint = new OpenCvSharp.Point(maxLocation.X + elementImg.Width, maxLocation.Y + elementImg.Height);
            Cv2.Rectangle(img, maxLocation, tempPoint, new Scalar(0, 255, 0, 255), 2); // (B, G, R, A) 的線條寬度為2
        }
        return img.ToBitmap();
    }

    // 二值化影像
    public static Bitmap imgToBinary(Mat img,
        String binaryWay,
        int InRangeUpperBound,
        int InRangeLowerBound,
        bool DilateFlag,
        bool ErodeFlag,
        int Dilate_Erode_Mask_Size,
        String Dilate_Erode_Direction)
    {
        Mat img_gray = new Mat();
        Mat img_binary = new Mat();
        try
        {
            Cv2.CvtColor(img, img_gray, ColorConversionCodes.BGR2GRAY);
        }
        catch
        {
            img_gray = img;
        }

        if (binaryWay == "Otsu")
        {
            double otsuThreshold = Cv2.Threshold(img_gray, img_binary, 0, 255, ThresholdTypes.Otsu);
        }
        else if (binaryWay == "InRange")
        {
            Cv2.InRange(img_gray, InRangeLowerBound, InRangeUpperBound, img_binary);
        }

        // Dilate 或 Erode 使用
        if (DilateFlag || ErodeFlag)
        {
            Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(Dilate_Erode_Mask_Size, Dilate_Erode_Mask_Size));// XY方向
            if (Dilate_Erode_Direction == "X")
                element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(Dilate_Erode_Mask_Size, 1));// X方向
            else if(Dilate_Erode_Direction == "Y")
                element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(1, Dilate_Erode_Mask_Size));// Y方向
            if (DilateFlag)
                Cv2.Dilate(img_binary, img_binary, element);
            if (ErodeFlag)
                Cv2.Erode(img_binary, img_binary, element);
        }

        //Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(Dilate_Erode_Mask_Size, Dilate_Erode_Mask_Size));
        //Cv2.MorphologyEx(img_binary, img_binary, MorphTypes.Close, element);

        // 將二值化的影像中的 0 轉換為 255，並將 255 轉換為 0
        //Cv2.BitwiseNot(img_binary, img_binary);


        return BitmapConverter.ToBitmap(img_binary);
    }


    // Canny 邊緣偵測二值化
    public static Bitmap imgCanny(
        Mat img,
        int CannyUpperBound,
        int CannyLowerBound,
        bool DilateFlag,
        bool ErodeFlag,
        int Dilate_Erode_Mask_Size)
    {
        Mat img_binary = new Mat();


        // 高斯模糊
        OpenCvSharp.Size kernelSize = new OpenCvSharp.Size(5, 5);  // 设置高斯核的大小
        double sigmaX = 0;  // 标准差，如果为0，OpenCV会自动计算
        Cv2.GaussianBlur(img, img, kernelSize, sigmaX);
        // 定义锐化卷积核
        //InputArray kernel = InputArray.Create<float>(new float[3, 3] {
        //    { 0, -1, 0 },
        //    { -1, 3, -1 },
        //    { 0, -1, 0 } });

        //// 应用卷积核
        //Cv2.Filter2D(img, img, MatType.CV_8U, kernel);

        Cv2.Canny(
            img,
            img_binary,
            CannyLowerBound,
            CannyUpperBound,
            5);

        // Dilate 或 Erode 使用
        if (DilateFlag || ErodeFlag)
        {
            Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(Dilate_Erode_Mask_Size, Dilate_Erode_Mask_Size));
            if (DilateFlag)
                Cv2.Dilate(img_binary, img_binary, element);
            if (ErodeFlag)
                Cv2.Erode(img_binary, img_binary, element);
        }


        return BitmapConverter.ToBitmap(img_binary);
    }

    // Add other functions as needed
}