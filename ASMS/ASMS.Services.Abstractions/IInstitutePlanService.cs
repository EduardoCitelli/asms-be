using ASMS.Domain.Entities;
using ASMS.DTOs.InstitutePlan;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Services.Abstractions
{
    public interface IInstitutePlanService
    {
        Task<InstitutePlan> GetActivePlan(Func<IQueryable<InstitutePlan>, IIncludableQueryable<InstitutePlan, object>>? include = null);
        Task<BaseApiResponse<bool>> SetNewPlanToInstituteAsync(InstitutePlanCreateDto request);
    }
}