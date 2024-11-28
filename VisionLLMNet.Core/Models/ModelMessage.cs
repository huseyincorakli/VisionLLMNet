using System.Net;

namespace VisionLLMNet.Core.Models
{
    /// <summary>
    /// Represents a message response model that includes the content and the HTTP status code of the response.
    /// </summary>
    public class ModelMessage
    {
        /// <summary>
        /// Gets or sets the content of the message. This can be the actual message or data returned from an API request.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code associated with the message. This can indicate the success or failure of an operation.
        /// </summary>
        public HttpStatusCode? StatusCode { get; set; }
    }
}
