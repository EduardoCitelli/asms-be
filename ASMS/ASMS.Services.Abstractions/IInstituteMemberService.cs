using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IInstituteMemberService
    {
        Task<BaseApiResponse<PagedList<InstituteMemberListDto>>> GetListAsync(int pageNumber = 1,
                                                                              int pageSize = 10,
                                                                              Expression<Func<InstituteMember, bool>>? query = null,
                                                                              Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>>? include = null);
        Task<BaseApiResponse<InstituteMemberSingleDto>> GetOneAsync(long id);

        Task<BaseApiResponse<InstituteMemberSingleDto>> CreateAsync(InstituteMemberCreateDto dto);

        Task<BaseApiResponse<InstituteMemberSingleDto>> DeleteAsync(long id);

        Task<BaseApiResponse<InstituteMemberSingleDto>> UpdateAsync(InstituteMemberUpdateDto dto, Action<InstituteMemberUpdateDto, InstituteMember>? beforeToSaveAction = null);

        Task<BaseApiResponse<InstituteMemberSingleDto>> UpdateAsync(UpdateStatusInstituteMemberDto dto, Action<UpdateStatusInstituteMemberDto, InstituteMember>? beforeToSaveAction = null, Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>>? include = null);

        Task ValidateExistingAsync(long key);

        Task SetActivitiesToInstituteMemberWithoutSaveAsync(long instituteMemberId, IEnumerable<long> activities);

        Task<InstituteMember> GetEntityByIdAsync(long key, Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>>? include = null);
    }
}