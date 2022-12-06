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
            var claims = context.User.Claims;
            var instituteIdClaim = claims.SingleOrDefault(x => x.Type == ASMSConfiguration.InstituteIdClaim);

            if (instituteIdClaim != null)
            {
                var id = Convert.ToInt64(instituteIdClaim.Value);
                _instituteIdService.SetId(id);
            }

            await next(context);
        }
    }
}