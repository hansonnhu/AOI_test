﻿// Functions.cs
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

    // 找尋所有輪廓中，X值最小的點，與Y值最大的點
    public static (OpenCvSharp.Point topLeft, OpenCvSharp.Point bottomLeft) FindMinMaxPoints(OpenCvSharp.Point[] contour)
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

        return (topLeft, bottomLeft);
    }

    public static Bitmap imgRotate(
        Mat img,
        Mat targetImg,
        int CannyUpperBound,
        int CannyLowerBound,
        bool DilateFlag,
        bool ErodeFlag,
        int Dilate_Erode_Mask_Size)
    {
        // 圖像自動轉正(方框)
        // 先大約找出目標物(模板比對)
        Mat TImg = BitmapConverter.ToMat(findTarget(img, targetImg));
        Mat TImgBinary;
        // Canny 邊緣二值化
        //TImgBinary = BitmapConverter.ToMat(imgCanny(
        //    TImg,
        //    CannyUpperBound,
        //    CannyLowerBound,
        //    DilateFlag,
        //    ErodeFlag,
        //    Dilate_Erode_Mask_Size));
        string json = File.ReadAllText(rootPath + "\\parameter\\contours.json");
        OpenCvSharp.Point[][] Contours = JsonConvert.DeserializeObject<OpenCvSharp.Point[][]>(json);

        var (topLeft, bottomLeft) = FindMinMaxPoints(Contours[0]);






        // 取得方框左邊的兩個點，並且求得斜率
        //int topPoint_y = Convert.ToInt32((double)TImgBinary.Height * 2 / 5);
        //int bottomPoint_y = Convert.ToInt32((double)TImgBinary.Height * 3 / 5);
        //int topPoint_x = -1;
        //int bottomPoint_x = -1;
        //for (int i = 0; i < TImgBinary.Width; i++)
        //{
        //    Debug.WriteLine(TImgBinary.Get<byte>(topPoint_y, i));
        //    if (topPoint_x != -1 && bottomPoint_x != -1)
        //        break;
        //    if (TImgBinary.Get<byte>(topPoint_y, i) == 255 && topPoint_x == -1) // (y, x)
        //        topPoint_x = i;
        //    if (TImgBinary.Get<byte>(bottomPoint_y, i) == 255 && bottomPoint_x == -1) // (y, x)
        //        bottomPoint_x = i;
        //}

        //Point2f Point1 = new Point2f(minX, minY);
        //Point2f Point2 = new Point2f(maxX, maxY);

        // 計算兩點之間之項向量
        Vec2f vector = new Vec2f(topLeft.X - bottomLeft.X, topLeft.Y - bottomLeft.Y);
        double angleInRadians = Math.Atan2(vector.Item1, vector.Item0);


        // 將弧度轉換為角度，此為傾斜角度
        double alsntDegrees = angleInRadians * (180.0 / Math.PI);
        alsntDegrees += 90;
        Debug.WriteLine(alsntDegrees);
        if (Math.Abs(alsntDegrees) > 45)
        {
            if (alsntDegrees > 0) alsntDegrees -= 90;
            else alsntDegrees += 90;
        }

        Debug.WriteLine(topLeft);
        Debug.WriteLine(bottomLeft);
        Debug.WriteLine(alsntDegrees);
        return rotateWithAngle(TImg, alsntDegrees);


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
        String findContoursWay)
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
            Dilate_Erode_Mask_Size));

        // 找到輪廓
        OpenCvSharp.Point[][] contours;
        HierarchyIndex[] hierarchy;
        GlobalVariables.targetContours = new OpenCvSharp.Point[][] { };

        OpenCvSharp.Point [][] Contours = {};
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
        int counter = 0; // 全部輪廓index

        foreach (var cnt in Contours)
        {
            Cv2.MinEnclosingCircle(cnt, out Point2f center, out float radius);
            if (radius < solderBalls_minRadius || radius > solderBalls_maxRadius) {
                continue;
            }

            int pixelCount255 = CountPixelsInContour(img_binary, cnt);

            //if (!IsCircle(cnt, radius, pixelCount255, blobAreaRatio))
            //    continue;

            double area_ratio = pixelCount255 / (Math.Pow(radius, 2) * 3.14);
            // blob 面積占比大於 blobAreaRatioThreshold 才檢出
            if (area_ratio < blobAreaRatioThreshold) {
                continue;
            }
            
            GlobalVariables.targetContours = GlobalVariables.targetContours.Concat(new[] { cnt }).ToArray();
            Debug.WriteLine(GlobalVariables.targetContours.Length);
            


            var moments = Cv2.Moments(cnt);
            double x = moments.M10 / moments.M00;
            double y = moments.M01 / moments.M00;

            int radiusInt = (int)radius;

            if (pixelCount255 > solderBalls_maxArea)
                Cv2.Circle(img, Convert.ToInt32(center.X), Convert.ToInt32(center.Y), radiusInt, new Scalar(0, 0, 255, 255), 2);
            else
                Cv2.Circle(img, Convert.ToInt32(center.X), Convert.ToInt32(center.Y), radiusInt, new Scalar(0, 255, 0, 255), 2);
            
            counter++;
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
        int Dilate_Erode_Mask_Size)
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
        else if(binaryWay == "InRange")
        {
            Cv2.InRange(img_gray, InRangeLowerBound, InRangeUpperBound, img_binary);
        }

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