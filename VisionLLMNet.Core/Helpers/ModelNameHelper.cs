using System;
using VisionLLMNet.Core.Configurations;

namespace VisionLLMNet.Core.Helpers
{
    internal static class ModelNameHelper
    {
        public static string GetModelName(ModelType model)
        {
            switch (model)
            {
                case ModelType.Llama_Vision_Free:
                    return "meta-llama/Llama-Vision-Free";
                case ModelType.Llama_3_2_90B_Vision_Instruct_Turbo:
                    return "meta-llama/Llama-3.2-90B-Vision-Instruct-Turbo";
                default:
                    throw new ArgumentOutOfRangeException(nameof(model), model, null);
            }
        }
    }
}
