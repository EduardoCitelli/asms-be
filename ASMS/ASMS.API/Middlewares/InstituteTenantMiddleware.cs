using ASMS.CrossCutting.Constants;
using ASMS.CrossCutting.Services.Abstractions;

namespace ASMS.API.Middlewares
{
    public class InstituteTenantMiddleware : IMiddleware
    {
        private readonly IInstituteIdService _instituteIdService;

        public InstituteTenantMiddleware(IInstituteIdService instituteService)
        {
            _instituteIdService = instituteService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Headers.TryGetValue(ASMSConfiguration.HeaderInstituteIdProperty, out var values))
            {
                var id = Convert.ToInt64(values.FirstOrDefault());
                _instituteIdService.SetId(id);
            }

            await next(context);
        }
    }
}