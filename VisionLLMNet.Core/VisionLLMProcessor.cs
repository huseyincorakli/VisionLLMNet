using System.Threading.Tasks;
using VisionLLMNet.Core.Configurations;
using VisionLLMNet.Core.Helpers;
using VisionLLMNet.Core.Models;
using VisionLLMNet.Core.Services;

namespace VisionLLMNet.Core
{
    /// <summary>
    /// LLMs perform operations using TogetherAI APIs.
    /// </summary>
    public class VisionLLMProcessor
    {
        private readonly string _apiKey;
        private readonly VisionLLMApiService _visionLLMApiService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisionLLMProcessor"/> class with the provided API key.
        /// The API key is used to authenticate requests to the OCR service.
        /// Get and use your API key using the together.ai portal
        /// </summary>
        /// <param name="apiKey">The API key used to authenticate requests to the OCR service.</param>
        public VisionLLMProcessor(string apiKey)
        {
            _apiKey = apiKey;
            _visionLLMApiService = new VisionLLMApiService(apiKey);
        }

        /// <summary>
        /// Asynchronously processes an image from either a local file path or a URL and converts it into markdown 
        /// using Optical Character Recognition (OCR) with the specified model.
        /// </summary>
        /// <param name="filePathOrUrl">The file path of the image (local path) or the URL (remote) of the image.</param>
        /// <param name="model">The model to use for processing the image, specified by the ModelType enum.</param>
        /// <returns>
        /// A Task that represents the asynchronous operation. The task result contains a <see cref="ModelMessage"/> object that 
        /// includes the markdown content extracted from the image or an error message if the request fails.
        /// </returns>
        public async Task<ModelMessage> OCRAsync(string filePathOrUrl, ModelType model)
        {
            string visionLLM = ModelNameHelper.GetModelName(model);

            var markdown = await _visionLLMApiService.GetMarkDownAsync(filePathOrUrl, visionLLM);
            return markdown;
        }
    }
}
