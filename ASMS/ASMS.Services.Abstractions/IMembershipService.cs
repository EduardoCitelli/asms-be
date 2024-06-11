using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IMembershipService
    {
        Task<BaseApiResponse<MembershipSingleDto>> CreateAsync(MembershipCreateDto dto);
        Task<BaseApiResponse<MembershipSingleDto>> DeleteAsync(long id);
        Task<BaseApiResponse<PagedList<MembershipListDto>>> GetListAsync(int pageNumber = 1, int pageSize = 10, Expression<Func<Membership, bool>>? query = null, Func<IQueryable<Membership>, IIncludableQueryable<Membership, object>>? include = null);
        Task<BaseApiResponse<MembershipSingleDto>> GetOneAsync(long id);
        Task<BaseApiResponse<MembershipSingleDto>> UpdateAsync(MembershipUpdateDto dto);
        Task<Membership> GetEntityByIdAsync(long key, Func<IQueryable<Membership>, IIncludableQueryable<Membership, object>>? include = null);
    }
}