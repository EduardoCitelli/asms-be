namespace ASMS.Infrastructure.Automapper.Configurations
{
    using ASMS.Domain.Entities;
    using ASMS.DTOs.Plans;

    public static class PlanConfig
    {
        public static ASMSProfile AddPlanConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<PlanCreateDto, Plan>();
            profile.CreateMap<PlanUpdateDto, Plan>();
            #endregion

            #region Map From Entity
            profile.CreateMap<Plan, PlanSingleDto>();
            profile.CreateMap<Plan, PlanDto>();
            #endregion

            return profile;
        }
    }
}
