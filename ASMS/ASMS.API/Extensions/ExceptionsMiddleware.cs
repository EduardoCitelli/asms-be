using ASMS.Infrastructure.Exceptions;
using System.Net;
using System.Text.Json;

namespace ASMS.Infrastructure
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private string _request;

        public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _request = string.Empty;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                _request = await GetRequest(httpContext);
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            LogError(exception, httpContext);

            var httpResponse = httpContext.Response;

            httpResponse.ContentType = "application/json";
            httpResponse.StatusCode = exception is BaseException ex ?
                                      (int)ex.StatusCode :
                                      (int)HttpStatusCode.InternalServerError;

            string response = GetResponse(exception);

            await httpResponse.WriteAsync(response);
        }

        private async Task<string> GetRequest(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();

            var bodyAsText = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();

            httpContext.Request.Body.Position = 0;

            return bodyAsText;
        }

        private string GetResponse(Exception exception)
        {
            var model = new BaseApiResponse<object>(exception.Message);

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            return JsonSerializer.Serialize(model, serializeOptions);
        }

        private void LogError(Exception exception, HttpContext httpContext)
        {
            var message = $"Message: {exception.Message}{Environment.NewLine}" +
                          $"Path: {httpContext.Request.Path}{Environment.NewLine}" +
                          $"Request: {_request}";

            _logger.LogError(exception, message);
        }
    }
}