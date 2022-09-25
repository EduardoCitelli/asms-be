using ASMS.Domain.Entities;
using ASMS.DTOs.Roles;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    public static class RoleConfig
    {
        public static ASMSProfile AddRoleCofig(this ASMSProfile profile)
        {
            #region Map To Entity
            #endregion

            #region Map From Entity

            profile.CreateMap<Role, RoleListDto>();
            profile.CreateMap<Role, RoleBasicDto>();
            profile.CreateMap<Role, RoleDto>();

            #endregion

            return profile;
        }
    }
}
