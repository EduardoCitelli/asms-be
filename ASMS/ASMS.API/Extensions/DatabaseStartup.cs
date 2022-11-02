using ASMS.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ASMS.API.Extensions
{
    public static class DatabaseStartup
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ASMSDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public async static Task<WebApplication> CheckAndRunMigrations(this WebApplication app)
        {
            var context = app.Services.CreateScope()
                             .ServiceProvider.GetRequiredService<ASMSDbContext>();

            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

            if (pendingMigrations != null && pendingMigrations.Any())
                await context.Database.MigrateAsync();

            return app;
        }
    }
}