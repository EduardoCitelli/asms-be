namespace ASMS.Infrastructure.Automapper.Configurations
{
    using ASMS.Domain.Entities;
    using ASMS.DTOs.Plans;
    using ASMS.DTOs.Shared;

    internal static class PlanConfig
    {
        internal static ASMSProfile AddPlanConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<PlanCreateDto, Plan>();
            profile.CreateMap<PlanUpdateDto, Plan>();
            #endregion

            #region Map From Entity
            profile.CreateMap<Plan, PlanSingleDto>();
            profile.CreateMap<Plan, PlanDto>();
            profile.CreateMap<Plan, PlanListDto>();
            profile.CreateMap<Plan, ComboDto<int>>();
            #endregion

            return profile;
        }
    }
}
