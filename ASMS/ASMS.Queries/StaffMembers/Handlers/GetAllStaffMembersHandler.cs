using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using ASMS.Queries.StaffMembers.Requests;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Queries.StaffMembers.Handlers
{
    public class GetAllStaffMembersHandler : IRequestHandler<GetAllStaffMembers, BaseApiResponse<PagedList<StaffMemberListDto>>>
    {
        private readonly IStaffMemberService _staffMemberService;

        public GetAllStaffMembersHandler(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
        }

        public async Task<BaseApiResponse<PagedList<StaffMemberListDto>>> Handle(GetAllStaffMembers request, CancellationToken cancellationToken)
        {
            return await _staffMemberService.GetListAsync(request.Page,
                                                          request.Size,
                                                          null,
                                                          IncludeUser());
        }

        private static Func<IQueryable<StaffMember>, IIncludableQueryable<StaffMember, object>> IncludeUser() => x => x.Include(x => x.User);
    }
}
