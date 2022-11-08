using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public interface IPlanService
    {
        Task<BaseApiResponse<PlanSingleDto>> CreateAsync(PlanCreateDto planCreateDto);

        Task<BaseApiResponse<PlanSingleDto>> DeleteAsync(int id);

        Task<BaseApiResponse<PlanSingleDto>> UpdateAsync(PlanUpdateDto planUpdateDto);

        Task<BaseApiResponse<PlanSingleDto>> GetOneAsync(int id);

        Task<BaseApiResponse<PagedList<PlanDto>>> GetListAsync(int pageNumber = 1,
                                                               int pageSize = 10,
                                                               Func<IQueryable<Plan>, IIncludableQueryable<Plan, object>>? include = null);

        Task<BaseApiResponse<PagedList<PlanDto>>> GetListQueryAsync(Expression<Func<Plan, bool>> query,
                                                                    int pageNumber = 1,
                                                                    int pageSize = 10,
                                                                    Func<IQueryable<Plan>, IIncludableQueryable<Plan, object>>? include = null);
        Task<bool> ExistEntityAsync(Expression<Func<Plan, bool>> expression);
    }
}