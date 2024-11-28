using System;
using System.IO;

namespace VisionLLMNet.Core.Helpers
{
    internal static class UrlHelper
    {
        public static string EncodeImage(string imagePath)
        {
            byte[] imageFile = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageFile);
        }

        public static bool IsRemoteFile(string filePath)
        {
            return Uri.IsWellFormedUriString(filePath, UriKind.Absolute) &&
                   (filePath.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    filePath.StartsWith("https://", StringComparison.OrdinalIgnoreCase));
        }
    }
}
