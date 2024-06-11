using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMemberMemberships;
using ASMS.Infrastructure;

namespace ASMS.Services.Abstractions
{
    public interface IInstituteMemberMembershipService
    {
        Task<BaseApiResponse<long>> CreateAsync(InstituteMemberMembershipCreateDto dto, Action<InstituteMemberMembership>? actionBeforeSave = null);
    }
}