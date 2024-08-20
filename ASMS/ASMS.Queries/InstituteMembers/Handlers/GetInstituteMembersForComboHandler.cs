using ASMS.Domain.Entities;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Queries.InstituteMembers.Requests;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Queries.InstituteMembers.Handlers
{
    public class GetInstituteMembersForComboHandler : IRequestHandler<GetInstituteMembersForCombo, BaseApiResponse<IEnumerable<ComboDto<long>>>>
    {
        private readonly IInstituteMemberService _instituteMemberService;

        public GetInstituteMembersForComboHandler(IInstituteMemberService instituteMemberService)
        {
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> Handle(GetInstituteMembersForCombo request, CancellationToken cancellationToken)
        {
            var query = request.ActivityId != null ? GetQueryByActivity(request.ActivityId.Value) : null;
            var include = request.ActivityId != null ? GetIncludeToCheckAllowedActivity() : null;

            return await _instituteMemberService.GetForComboAsync(query, include);
        }

        private static Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>> GetIncludeToCheckAllowedActivity()
        {
            return x => x.Include(x => x.Memberships)
                         .ThenInclude(x => x.Membership)
                         .Include(x => x.User)
                         .Include(x => x.AllowedActivities);
        }

        private static Expression<Func<InstituteMember, bool>> GetQueryByActivity(long activityId)
        {
            return x => x.Memberships.SingleOrDefault(x => x.IsActiveMembership) != null &&
                        (x.Memberships.SingleOrDefault(x => x.IsActiveMembership)!.Membership.IsPremium ||
                         x.AllowedActivities.Select(x => x.ActivityId).Contains(activityId));
        }
    }
}
