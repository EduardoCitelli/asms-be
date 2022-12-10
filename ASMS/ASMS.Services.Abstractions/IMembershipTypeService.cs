using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.MembershipTypes;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IMembershipTypeService
    {
        Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> GetForComboAsync();

        Task<BaseApiResponse<PagedList<MembershipTypeListDto>>> GetListAsync(int pageNumber = 1, 
                                                                             int pageSize = 10, 
                                                                             Expression<Func<MembershipType, bool>>? query = null, 
                                                                             Func<IQueryable<MembershipType>, IIncludableQueryable<MembershipType, object>>? include = null);

        Task<BaseApiResponse<MembershipTypeSingleDto>> GetOneAsync(long id);

        Task<BaseApiResponse<MembershipTypeSingleDto>> CreateAsync(MembershipTypeCreateDto dto);

        Task<BaseApiResponse<MembershipTypeSingleDto>> UpdateAsync(MembershipTypeUpdateDto dto);

        Task<BaseApiResponse<MembershipTypeSingleDto>> DeleteAsync(long id);
    }
}