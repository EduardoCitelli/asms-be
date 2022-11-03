using ASMS.API.Middlewares;

namespace ASMS.API.Extensions
{
    public static class MiddlewareStartup
    {
        public static IServiceCollection ConfigureMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<InstituteTenantMiddleware>();
            services.AddScoped<ExceptionsMiddleware>();
            services.AddScoped<UserInfoMiddleware>();

            return services;
        }

        public static WebApplication UseMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ExceptionsMiddleware>();
            app.UseMiddleware<InstituteTenantMiddleware>();
            app.UseMiddleware<UserInfoMiddleware>();

            return app;
        }
    }
}