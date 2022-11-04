using ASMS.Domain.Entities;
using ASMS.DTOs.Users;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    public static class UserConfig
    {
        public static ASMSProfile AddUserCofig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<UserBasicWithPasswordDto, User>()
                   .ForMember(entity => entity.Password, config => config.Ignore());

            profile.CreateMap<UserCreateDto, User>();
            #endregion

            #region Map From Entity
            profile.CreateMap<User, UserBasicDto>();
            #endregion

            return profile;
        }
    }
}
