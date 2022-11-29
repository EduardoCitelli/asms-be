using ASMS.Domain.Entities;
using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IActivityService
    {
        Task<BaseApiResponse<ActivitySingleDto>> CreateAsync(ActivityCreateDto dto);

        Task<BaseApiResponse<ActivitySingleDto>> UpdateAsync(ActivityUpdateDto dto);

        Task<BaseApiResponse<ActivitySingleDto>> DeleteAsync(long id);
        Task<bool> AnyAsync(Expression<Func<Activity, bool>> query, Func<IQueryable<Activity>, IIncludableQueryable<Activity, object>>? include = null);
    }
}