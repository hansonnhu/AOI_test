using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Text;

public class ImageProcessor
{
    public static async Task<string> ProcessImage(string apiUrl, byte[] imageBytes)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                var content = new MultipartFormDataContent();
                content.Add(new ByteArrayContent(imageBytes), "image", "image.jpg");

                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }
    }
    public async Task<byte[]> http_gray_image(byte[] imageBytes)
    {
        // httpToGray 測試
        byte[] processedImageBytes;
        try
        {
            var imageUrl = "http://127.0.0.1:5000/gray_image";  // 根據你的伺服器地址調整
            var result = await ImageProcessor.ProcessImage(imageUrl, imageBytes);
            JObject jsonObject = JObject.Parse(result);
            string processedImageString = jsonObject["gray_image"].ToString();
            processedImageBytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(processedImageString);
            return processedImageBytes;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            return null;
        }
    }

    public async Task<byte[]> http_solderBalls_detect(byte[] imageBytes)
    {
        // httpToGray 測試
        byte[] processedImageBytes;
        try
        {
            var imageUrl = "http://127.0.0.1:5000/solderBalls_detect";  // 根據你的伺服器地址調整
            var result = await ImageProcessor.ProcessImage(imageUrl, imageBytes);
            JObject jsonObject = JObject.Parse(result);
            string processedImageString = jsonObject["solderBalls_detect"].ToString();
            processedImageBytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(processedImageString);
            return processedImageBytes;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            return null;
        }
    }

    public async Task<byte[]> http_template_match(byte[] imageBytes)
    {
        // httpToGray 測試
        byte[] processedImageBytes;
        try
        {
            var imageUrl = "http://127.0.0.1:5000/template_match";  // 根據你的伺服器地址調整
            var result = await ImageProcessor.ProcessImage(imageUrl, imageBytes);
            JObject jsonObject = JObject.Parse(result);
            string processedImageString = jsonObject["template_match"].ToString();
            processedImageBytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(processedImageString);
            return processedImageBytes;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            return null;
        }
    }

}