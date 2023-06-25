using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IStaffMemberService
    {
        Task<BaseApiResponse<PagedList<StaffMemberListDto>>> GetListAsync(int pageNumber = 1, 
                                                                          int pageSize = 10, 
                                                                          Expression<Func<StaffMember, bool>>? query = null, 
                                                                          Func<IQueryable<StaffMember>, IIncludableQueryable<StaffMember, object>>? include = null);
        Task<BaseApiResponse<StaffMemberSingleDto>> GetOneAsync(long id);
        Task<BaseApiResponse<StaffMemberSingleDto>> CreateAsync(StaffMemberCreateDto dto);
        Task<BaseApiResponse<StaffMemberSingleDto>> DeleteAsync(long id);
        Task<BaseApiResponse<StaffMemberSingleDto>> UpdateAsync(StaffMemberUpdateDto dto);
    }
}