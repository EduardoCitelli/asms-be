using System.Net;
using System.Text.Json;

namespace ASMS.Infrastructure.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public BaseException(IEnumerable<string> messages, HttpStatusCode statusCode)
            : base(JsonSerializer.Serialize(messages))
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
