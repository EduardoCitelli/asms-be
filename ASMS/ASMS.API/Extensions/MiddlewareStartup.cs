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
            services.AddScoped<ClientOffsetMiddleware>();
            return services;
        }

        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ClientOffsetMiddleware>();
            app.UseMiddleware<ExceptionsMiddleware>();
            app.UseMiddleware<InstituteTenantMiddleware>();
            app.UseMiddleware<UserInfoMiddleware>();

            return app;
        }
    }
}