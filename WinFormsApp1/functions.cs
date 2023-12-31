﻿// Functions.cs
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;
using Newtonsoft.Json;



public class GlobalVariables
{
    // 所有 blob 的輪廓點
    public static OpenCvSharp.Point[][] targetContours;
}

public class ImgToBinary
{
    public string binaryWay { get; set; }
    public int inRangeUpperBound { get; set; }
    public int inRangeLowerBound { get; set; }
    public bool invertBinaryFlag { get; set; }
    public bool dilateFlag { get; set; }
    public bool erodeFlag { get; set; }
    public int dilateErodeMaskSize { get; set; }
    public string dilateErodeDirection { get; set; }


    public Mat ConvertToBinary(Mat img)
    {
        Mat imgGray = new Mat();
        Mat imgBinary = new Mat();
        try
        {
            Cv2.CvtColor(img, imgGray, ColorConversionCodes.BGR2GRAY);
        }
        catch
        {
            imgGray = img;
        }

        if (binaryWay == "Otsu")
        {
            Cv2.Threshold(imgGray, imgBinary, 0, 255, ThresholdTypes.Otsu);
        }
        else if (binaryWay == "InRange")
        {
            Cv2.InRange(imgGray, inRangeLowerBound, inRangeUpperBound, imgBinary);
        }

        if (dilateFlag || erodeFlag)
        {
            Mat element = GetStructuringElement(dilateErodeMaskSize, dilateErodeDirection);
            if (dilateFlag)
                Cv2.Dilate(imgBinary, imgBinary, element);
            if (erodeFlag)
                Cv2.Erode(imgBinary, imgBinary, element);
        }

        if (invertBinaryFlag)
            Cv2.BitwiseNot(imgBinary, imgBinary);

        return imgBinary;
    }

    // 回傳 Dilate/Erode mask 的方向以及大小
    private static Mat GetStructuringElement(int dilateErodeMaskSize, string dilateErodeDirection)
    {
        Mat element;
        if (dilateErodeDirection == "X")
            element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(dilateErodeMaskSize, 1));
        else if (dilateErodeDirection == "Y")
            element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(1, dilateErodeMaskSize));
        else
            element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(dilateErodeMaskSize, dilateErodeMaskSize));

        return element;
    }
}

// 利用閾值篩選出特定 blob
public class BlobSelector
{
    public int blobMaxArea { get; set; }
    public int blobMinRadius { get; set; }
    public int blobMaxRadius { get; set; }
    public double blobAreaRatioThreshold { get; set; }
    public string findContoursWay { get; set; }


    public Bitmap SelectBlobWithAreaRatio(Mat binaryImg, Mat oriImg)
    {
        //Mat img_binary = new Mat();
        // 找到輪廓
        OpenCvSharp.Point[][] contours;
        HierarchyIndex[] hierarchy;
        GlobalVariables.targetContours = new OpenCvSharp.Point[][] { };

        OpenCvSharp.Point[][] Contours = { };
        if (findContoursWay == "External")
        {
            Cv2.FindContours(binaryImg, out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            Contours = contours;
        }

        else if (findContoursWay == "List")
        {
            Cv2.FindContours(binaryImg, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);
            Contours = contours;
        }

        foreach (var cnt in Contours)
        {
            Cv2.MinEnclosingCircle(cnt, out Point2f center, out float radius);
            if (radius < blobMinRadius || radius > blobMaxRadius)
            {
                continue;
            }

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
            
            try
            {
                // 將灰階轉為彩色
                Cv2.CvtColor(oriImg, oriImg, ColorConversionCodes.GRAY2RGBA);
            }
            catch
            {
                // 本來就是彩色
            }

            var oneContour = cnt;
            Cv2.DrawContours(oriImg, new[] { oneContour }, -1, new Scalar(76, 153, 0, 255), 2);

            int radiusInt = (int)radius;
            if (blobArea > blobMaxRadius)
                Cv2.Circle(oriImg, Convert.ToInt32(center.X), Convert.ToInt32(center.Y), radiusInt, new Scalar(0, 0, 255, 255), 2);
            else
                Cv2.Circle(oriImg, Convert.ToInt32(center.X), Convert.ToInt32(center.Y), radiusInt, new Scalar(0, 255, 0, 255), 2);
        }
        return BitmapConverter.ToBitmap(oriImg);
    }
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

    //static int CountPixelsInContour(Mat image, OpenCvSharp.Point[] contour)
    //{
    //    Mat mask = new Mat(image.Size(), MatType.CV_8UC1, Scalar.Black);
    //    Cv2.DrawContours(mask, new List<OpenCvSharp.Point[]> { contour }, -1, Scalar.White, -1);
    //    int count = Cv2.CountNonZero(mask);
    //    mask.Dispose();
    //    return count;
    //}

    // 找尋第一個 blob 輪廓中，X值最小的點，與Y值最大的點
    //public static (OpenCvSharp.Point topLeft, OpenCvSharp.Point bottomLeft, OpenCvSharp.Point topRight, OpenCvSharp.Point bottomRight) FindFourTopPoints(OpenCvSharp.Point[] contour)
    //{
    //    if (contour == null || contour.Length == 0)
    //        throw new ArgumentException("Invalid contour");

    //    // 初始化點
    //    OpenCvSharp.Point topLeft = contour[0];
    //    OpenCvSharp.Point topRight = contour[0];
    //    OpenCvSharp.Point bottomLeft = contour[0];
    //    OpenCvSharp.Point bottomRight = contour[0];

    //    foreach (var point in contour)
    //    {
    //        // 找最左上的點
    //        if ((point.X + point.Y) < (topLeft.X + topLeft.Y))
    //            topLeft = point;

    //        // 找最右上的點
    //        if ((point.X - point.Y) > (topRight.X - topRight.Y))
    //            topRight = point;

    //        // 找最左下的點
    //        if ((point.X - point.Y) < (bottomLeft.X - bottomLeft.Y))
    //            bottomLeft = point;

    //        // 找最右下的點
    //        if ((point.X + point.Y) > (bottomRight.X + bottomRight.Y))
    //            bottomRight = point;
    //    }
    //    Debug.WriteLine(topLeft);
    //    Debug.WriteLine(bottomLeft);

    //    return (topLeft, bottomLeft, topRight, bottomRight);
    //}

    // 找尋所有 blobs 的外接圓圓心的最左上角以及最右下角圓心點
    //public static (OpenCvSharp.Point topLeft, OpenCvSharp.Point bottomLeft) FindTwoCircleCenter(OpenCvSharp.Point[][] contours)
    //{
    //    if (contours == null || contours.Length == 0)
    //        throw new ArgumentException("Invalid contour");

    //    // 初始化點
    //    OpenCvSharp.Point topLeftCircleCenter = contours[0][0];
    //    OpenCvSharp.Point bottomLeftCircleCenter = contours[0][0];

    //    foreach (OpenCvSharp.Point[] contour in contours)
    //    {
    //        Cv2.MinEnclosingCircle(contour, out Point2f center, out float radius);
    //        // 找最左上的點
    //        if ((center.X + center.Y) < (topLeftCircleCenter.X + topLeftCircleCenter.Y))
    //        {
    //            topLeftCircleCenter.X = Convert.ToInt32(center.X);
    //            topLeftCircleCenter.Y = Convert.ToInt32(center.Y);
    //        }
    //        // 找最左下的點
    //        if ((center.X - center.Y) < (bottomLeftCircleCenter.X - bottomLeftCircleCenter.Y))
    //        {
    //            bottomLeftCircleCenter.X = Convert.ToInt32(center.X);
    //            bottomLeftCircleCenter.Y = Convert.ToInt32(center.Y);
    //        }
    //    }
    //    return (topLeftCircleCenter, bottomLeftCircleCenter);
    //}

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

    // 測試
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