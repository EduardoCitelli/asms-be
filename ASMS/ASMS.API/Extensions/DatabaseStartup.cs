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
    }
}