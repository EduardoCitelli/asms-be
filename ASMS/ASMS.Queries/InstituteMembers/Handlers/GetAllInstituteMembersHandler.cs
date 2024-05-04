using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using ASMS.Queries.InstituteMembers.Requests;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Queries.InstituteMembers.Handlers
{
    public class GetAllInstituteMembersHandler : IRequestHandler<GetAllInstituteMember, BaseApiResponse<PagedList<InstituteMemberListDto>>>
    {
        private readonly IInstituteMemberService _instituteMemberService;

        public GetAllInstituteMembersHandler(IInstituteMemberService instituteMemberService)
        {
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<PagedList<InstituteMemberListDto>>> Handle(GetAllInstituteMember request, CancellationToken cancellationToken)
        {
            return await _instituteMemberService.GetListAsync(request.Page,
                                                              request.Size,
                                                              ExcludeAdminUsers(),
                                                              IncludeUser());
        }

        private static Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>> IncludeUser() => x => x.Include(x => x.User)
                                                                                                                               .ThenInclude(x => x.UserRoles);

        private static Expression<Func<InstituteMember, bool>> ExcludeAdminUsers() => x => !x.User.UserRoles.Any(x => x.RoleId == RoleTypeEnum.SuperAdmin);
    }
}
