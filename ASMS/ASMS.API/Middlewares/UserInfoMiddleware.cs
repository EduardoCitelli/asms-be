using ASMS.CrossCutting.Constants;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Services.Models;
using System.Security.Claims;
using System.Text.Json;

namespace ASMS.API.Middlewares
{
    public class UserInfoMiddleware : IMiddleware
    {
        private readonly IUserInfoService _userInfoService;

        public UserInfoMiddleware(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var claims = context.User.Claims;
            var email = claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (email != null)
            {
                var userInfo = new UserInfo
                {
                    Id = Convert.ToInt64(GetClaimValue(ASMSConfiguration.IdClaim, claims)),
                    Email = email.Value,
                    UserName = GetClaimValue(ClaimTypes.NameIdentifier, claims),
                    FirstName = GetClaimValue(ClaimTypes.Name, claims),
                    LastName = GetClaimValue(ClaimTypes.Surname, claims),

                    Roles = claims.Where(x => x.Type == ClaimTypes.Role)
                                  .Select(x => Enum
                                  .Parse<RoleTypeEnum>(x.Value))
                };

                _userInfoService.Set(userInfo);
            }

            await next(context);
        }

        private string GetClaimValue(string key, IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == key)!.Value;
        }
    }
}
