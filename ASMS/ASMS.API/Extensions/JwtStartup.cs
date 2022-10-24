using ASMS.CrossCutting.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ASMS.API.Extensions
{
    public static class JwtStartup
    {
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var authSettings = configuration.GetSection(nameof(AuthSettings));
            services.Configure<AuthSettings>(authSettings);

            var settings = authSettings.Get<AuthSettings>();

            var key = Encoding.ASCII.GetBytes(settings.SecretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuerSigningKey = true,
                            ValidateIssuer = false,
                            ValidateAudience = false,
                        };
                    });

            return services;
        }
    }
}
