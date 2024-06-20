using ASMS.Domain.Entities;
using ASMS.DTOs.Activities;
using ASMS.DTOs.Shared;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class ActivityConfig
    {
        internal static ASMSProfile AddActivityConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<ActivityCreateDto, Activity>();
            profile.CreateMap<ActivityUpdateDto, Activity>();
            #endregion

            #region Map From Entity
            profile.CreateMap<Activity, ActivitySingleDto>();
            profile.CreateMap<Activity, ActivityListDto>();
            profile.CreateMap<Activity, ComboDto<long>>();
            #endregion

            return profile;
        }
    }
}