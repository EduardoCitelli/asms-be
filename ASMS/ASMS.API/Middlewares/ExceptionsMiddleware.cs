using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using GTranslate;
using GTranslate.Translators;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace ASMS.API.Middlewares
{
    public class ExceptionsMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        private readonly ITranslateService _translateService;
        private string _request;
        private string _languague;

        public ExceptionsMiddleware(ILogger<ExceptionsMiddleware> logger, 
                                    ITranslateService translateService)
        {
            _logger = logger;
            _translateService = translateService;
            _request = string.Empty;
            _languague = string.Empty;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                _request = await GetRequest(httpContext);

                SetLanguague(httpContext);

                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private void SetLanguague(HttpContext httpContext)
        {
            var languague = httpContext.Request.GetTypedHeaders()
                                               .AcceptLanguage
                                               .FirstOrDefault()?
                                               .ToString() ?? "";

            _languague = CultureInfo.GetCultureInfoByIetfLanguageTag(languague)
                                    .TwoLetterISOLanguageName;
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            LogError(exception, httpContext);

            var httpResponse = httpContext.Response;

            httpResponse.ContentType = "application/json";
            httpResponse.StatusCode = exception is BaseException ex ?
                                      (int)ex.StatusCode :
                                      (int)HttpStatusCode.InternalServerError;

            string response = await GetResponse(exception);

            await httpResponse.WriteAsync(response);
        }

        private async Task<string> GetRequest(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();

            var bodyAsText = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();

            httpContext.Request.Body.Position = 0;

            return bodyAsText;
        }

        private async Task<string> GetResponse(Exception exception)
        {
            var translate = await _translateService.TranslateAsync(exception.Message, _languague);

            var model = new BaseApiResponse<object>(translate.Translation);

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