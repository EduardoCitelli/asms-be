using ASMS.CrossCutting.Constants;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Services.Abstractions;

namespace ASMS.API.Middlewares
{
    public class InstituteTenantMiddleware : IMiddleware
    {
        private readonly IInstituteService _instituteService;

        public InstituteTenantMiddleware(IInstituteService instituteService)
        {
            _instituteService = instituteService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Headers.TryGetValue(ASMSConfiguration.HeaderInstituteIdProperty, out var values))
            {
                var id = Convert.ToInt64(values.FirstOrDefault());
                _instituteService.SetId(id);
            }

            await next(context);
        }
    }
}