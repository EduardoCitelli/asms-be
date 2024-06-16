using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMemberMemberships;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Services.Abstractions
{
    public interface IInstituteMemberMembershipService
    {
        Task<BaseApiResponse<long>> CreateAsync(InstituteMemberMembershipCreateDto dto, Action<InstituteMemberMembership>? actionBeforeSave = null);
        Task<InstituteMemberMembership> GetEntityActiveByInstituteMemberAsync(long instituteMemberId, Func<IQueryable<InstituteMemberMembership>, IIncludableQueryable<InstituteMemberMembership, object>>? include = null);
        Task SetInactiveMembershipsWithoutSave(long instituteMemberId);
        Task UpdateWithoutSaveAsync(InstituteMemberMembership entity);
        Task ValidateTryToAssignSameMembership(long instituteMemberId, long membershipId);
    }
}