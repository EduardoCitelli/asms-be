using System.Net;

namespace ASMS.Infrastructure.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message)
            : base(message, HttpStatusCode.BadRequest)
        {
        }

        public BadRequestException(IEnumerable<string> messages)
            : base(messages, HttpStatusCode.BadRequest)
        {
        }
    }
}