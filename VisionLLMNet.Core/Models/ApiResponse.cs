using System.Collections.Generic;
using System.Net;

namespace VisionLLMNet.Core.Models
{
    internal class ApiResponse
    {
        public List<Choice> choices { get; set; }
    }
    internal class Choice
    {
        public string role { get; set; }
        public Message message { get; set; }
    }

    internal class Message
    {
        public string content { get; set; }
    }
}
