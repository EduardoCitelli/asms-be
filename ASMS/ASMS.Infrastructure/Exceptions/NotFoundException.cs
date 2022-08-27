using System.Net;

namespace ASMS.Infrastructure.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message)
            : base(message, HttpStatusCode.NotFound)
        {
        }

        public NotFoundException(IEnumerable<string> messages)
            : base(messages, HttpStatusCode.NotFound)
        {
        }
    }
}
