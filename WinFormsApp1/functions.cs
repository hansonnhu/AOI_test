// Functions.cs
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;
using System;
using System.Net.NetworkInformation;


public class Functions
{
    public int marginSize = 50;
    public static byte[] ImageToByte(Image img)
    {
        // bmp to byte function
        ImageConverter converter = new ImageConverter();
        return (byte[])converter.ConvertTo(img, typeof(byte[]));
    }
    public static Bitmap ConvertByteArrayToBitmap(byte[] byteArray)
    {
        // byte to bmp function
        using (var ms = new MemoryStream(byteArray))
        {
            return new Bitmap(ms);
        }
    }
    //旋轉圖像
    
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

    static int CountPixelsInContour(Mat image, OpenCvSharp.Point[] contour)
    {
        Mat mask = new Mat(image.Size(), MatType.CV_8UC1, Scalar.Black);
        Cv2.DrawContours(mask, new List<OpenCvSharp.Point[]> { contour }, -1, Scalar.White, -1);
        int count = Cv2.CountNonZero(mask);
        mask.Dispose();
        return count;
    }
    static bool IsCircle(OpenCvSharp.Point[] contour, double radius, int pixel_count_255, double blobAreaRatio)
    {
        //double perimeter = Cv2.ArcLength(contour, true);
        //double circularity = 4 * Math.PI * pixelCount255 / Math.Pow(perimeter, 2);
        double area_ratio = pixel_count_255 / (Math.Pow(radius, 2) * 3.14);
        return area_ratio >= blobAreaRatio;
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


    public static Bitmap selectBlobWithAreaRatio(Mat img,
        String binaryWay,
        int InRangeUpperBound,
        int InRangeLowerBound,
        bool DilateFlag,
        bool ErodeFlag,
        int Dilate_Erode_Mask_Size,
        int solderBalls_maxArea,
        int solderBalls_minRadius,
        int solderBalls_maxRadius,
        double blobAreaRatio,
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

        foreach (var cnt in Contours)
        {
            Cv2.MinEnclosingCircle(cnt, out Point2f center, out float radius);
            if (radius < solderBalls_minRadius || radius > solderBalls_maxRadius)
                continue;

            int pixelCount255 = CountPixelsInContour(img_binary, cnt);

            if (!IsCircle(cnt, radius, pixelCount255, blobAreaRatio))
                continue;

            var moments = Cv2.Moments(cnt);
            double x = moments.M10 / moments.M00;
            double y = moments.M01 / moments.M00;

            int radiusInt = (int)radius;

            if (pixelCount255 > solderBalls_maxArea)
                Cv2.Circle(img, Convert.ToInt32(center.X), Convert.ToInt32(center.Y), radiusInt, new Scalar(0, 0, 255, 255), 2);
            else
                Cv2.Circle(img, Convert.ToInt32(center.X), Convert.ToInt32(center.Y), radiusInt, new Scalar(0, 255, 0, 255), 2);
        }
        return BitmapConverter.ToBitmap(img);
    }

    public static Bitmap findTarget(Mat img, Mat targetImg)
    {
        // 找尋影像中的目標(晶圓)
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

    public static Bitmap findElement(Mat img, Mat elementImg)
    {
        // 找尋影像中 element
        Console.WriteLine("This is findElement Function");

        Mat result = new Mat();

        // 影像轉灰階
        Mat grayElementImage = new Mat();
        Cv2.CvtColor(elementImg, grayElementImage, ColorConversionCodes.BGR2GRAY);
        Mat grayimg = new Mat();
        Cv2.CvtColor(img, grayimg, ColorConversionCodes.BGR2GRAY);

        // 模板比對
        Cv2.MatchTemplate(grayimg, grayElementImage, result, TemplateMatchModes.CCoeffNormed);


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
    // Add other functions as needed
}