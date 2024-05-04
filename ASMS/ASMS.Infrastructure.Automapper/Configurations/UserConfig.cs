using ASMS.Domain.Entities;
using ASMS.DTOs.MyUser;
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

            profile.CreateMap<UserUpdateDto, User>();

            profile.CreateMap<UpdateMyUserDto, User>();

            profile.CreateMap<UserCreateDto, User>()
                   .ForMember(entity => entity.UserRoles, config => config.MapFrom(dto => dto.Roles.Select(role => new UserRole { RoleId = role })));
                   
            #endregion

            #region Map From Entity
            profile.CreateMap<User, UserBasicDto>();
            profile.CreateMap<User, UserListDto>();
            #endregion

            return profile;
        }
    }
}
