using ASMS.Domain.Entities;
using ASMS.DTOs.Users;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class UserConfig
    {
        internal static ASMSProfile AddUserConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<UserBasicWithPasswordDto, User>();

            profile.CreateMap<UserBasicDto, User>();

            profile.CreateMap<UserCreateDto, User>()
                   .ForMember(entity => entity.UserRoles, config => config.MapFrom(dto => dto.Roles.Select(role => new UserRole { RoleId = role })));
                   
            #endregion

            #region Map From Entity
            profile.CreateMap<User, UserBasicDto>();
            #endregion

            return profile;
        }
    }
}
