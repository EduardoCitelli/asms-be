namespace ASMS.API.Extensions
{
    public static class CorsStartup
    {
        public static IServiceCollection InitializeCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.SetIsOriginAllowed(hostName => true)
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                });
            });

            return services;
        }
    }
}