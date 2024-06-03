using ASMS.DTOs.InstitutePlan;
using ASMS.Infrastructure;

namespace ASMS.Services.Abstractions
{
    public interface IInstitutePlanService
    {
        Task<BaseApiResponse<bool>> SetNewPlanToInstituteAsync(InstitutePlanCreateDto request);
    }
}