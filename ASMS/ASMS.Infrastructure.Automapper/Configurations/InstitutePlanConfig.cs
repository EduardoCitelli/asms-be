using ASMS.Domain.Entities;
using ASMS.DTOs.InstitutePlan;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class InstitutePlanConfig
    {
        internal static ASMSProfile AddInstitutePlanConfig(this ASMSProfile profile)
        {
            #region Map to Entity
            profile.CreateMap<InstitutePlanCreateDto, InstitutePlan>();
            #endregion

            return profile;
        }
    }
}
