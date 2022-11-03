using ASMS.Domain.Entities;
using ASMS.DTOs.Auth;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    public static class AuthConfig
    {
        public static ASMSProfile AddAuthCofig(this ASMSProfile profile)
        {
            #region Map To Entity
            #endregion

            #region Map From Entity
            profile.CreateMap<User, AuthResponseDto>();
            #endregion

            return profile;
        }
    }
}