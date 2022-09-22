using System.Net;

namespace ASMS.Infrastructure.Exceptions
{
    public class InternalErrorException : BaseException
    {
        public InternalErrorException(string message)
            : base(message, HttpStatusCode.InternalServerError)
        {
        }

        public InternalErrorException(IEnumerable<string> messages)
            : base(messages, HttpStatusCode.InternalServerError)
        {
        }
    }
}
