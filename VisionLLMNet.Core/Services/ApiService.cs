using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System;
using VisionLLMNet.Core.Configurations;
using VisionLLMNet.Core.Helpers;
using VisionLLMNet.Core.Models;
using System.IO;

namespace VisionLLMNet.Core.Services
{
    internal class VisionLLMApiService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public VisionLLMApiService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        

        public async Task<ModelMessage> GetMarkDownAsync(string filePathOrUrl, string visionLLM)
        {
            if (UrlHelper.IsRemoteFile(filePathOrUrl))
            {
                return await RequestMarkdownFromAPI(filePathOrUrl, visionLLM);
            }
            else if (File.Exists(filePathOrUrl))
            {
                string encodedImage = "data:image/jpeg;base64," + UrlHelper.EncodeImage(filePathOrUrl);
                return await RequestMarkdownFromAPI(encodedImage, visionLLM);
            }
            else
            {
                throw new ArgumentException("The provided image path or URL is invalid.");
            }
        }

        private async Task<ModelMessage> RequestMarkdownFromAPI(string imageUrlOrBase64, string visionLLM)
        {
            var requestBody = new
            {
                model = visionLLM,
                messages = new object[]
                {
                    new
                    {
                        role = "system",
                        content = SystemPrompt.Prompt 
                    },
                    new
                    {
                        role = "user",
                        content = new object[]
                        {
                            new { type = "text", text = "Here is the image:" },
                            new { type = "image_url", image_url = new { url = imageUrlOrBase64 } }
                        }
                    }
                }
            };

            var jsonRequestBody = JsonSerializer.Serialize(requestBody);
            var requestContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.PostAsync("https://api.together.ai/v1/chat/completions", requestContent);
            if (((int)response.StatusCode) == 429)
                return new ModelMessage()
                {
                    content = "Too many requests",
                    StatusCode = response.StatusCode,
                };
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse>(responseContent);

            return new ModelMessage()
            {
                content = result?.choices?[0]?.message?.content,
                StatusCode = response.StatusCode
            };
        }
    }
}
