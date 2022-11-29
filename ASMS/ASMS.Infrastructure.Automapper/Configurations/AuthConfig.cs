using ASMS.Domain.Entities;
using ASMS.DTOs.Auth;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class AuthConfig
    {
        internal static ASMSProfile AddAuthConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            #endregion

            #region Map From Entity
            profile.CreateMap<User, AuthResponseDto>()
                   .ForMember(dto => dto.Roles, conf => conf.MapFrom(entity => entity.UserRoles.Select(x => x.RoleId)));
            #endregion

            return profile;
        }
    }
}