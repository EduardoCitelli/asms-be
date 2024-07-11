using ASMS.CrossCutting.Services.Abstractions;

namespace ASMS.API.Middlewares
{
    public class ClientOffsetMiddleware : IMiddleware
    {
        private const string MinutesOffsetHeaderKey = "minutes-offset";
        private readonly IClientTimeOffsetService _timeOffsetService;

        public ClientOffsetMiddleware(IClientTimeOffsetService timeOffsetService)
        {
            _timeOffsetService = timeOffsetService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var offsetHeader = context.Request.Headers[MinutesOffsetHeaderKey];

            if (offsetHeader.Any())
                _timeOffsetService.SetOffset(Convert.ToInt32(offsetHeader[0]));

            await next(context);
        }
    }
}