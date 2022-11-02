using ASMS.API.Middlewares;

namespace ASMS.API.Extensions
{
    public static class MiddlewareStartup
    {
        public static WebApplication ConfigMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ExceptionsMiddleware>();
            app.UseMiddleware<InstituteTenantMiddleware>();

            return app;
        }
    }
}