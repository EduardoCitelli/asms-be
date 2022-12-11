using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface ICoachService
    {
        Task<BaseApiResponse<CoachSingleDto>> CreateAsync(CoachCreateDto dto);
        Task<BaseApiResponse<CoachSingleDto>> DeleteAsync(long id);
        Task<BaseApiResponse<PagedList<CoachListDto>>> GetListAsync(int pageNumber = 1, int pageSize = 10, Expression<Func<Coach, bool>>? query = null, Func<IQueryable<Coach>, IIncludableQueryable<Coach, object>>? include = null);
        Task<BaseApiResponse<CoachSingleDto>> GetOneAsync(long id);
        Task<BaseApiResponse<CoachSingleDto>> UpdateAsync(CoachUpdateDto dto);
    }
}