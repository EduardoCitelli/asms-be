using ASMS.CrossCutting.Enums;
using ASMS.Infrastructure;
using ASMS.Queries.Users.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Users.Handlers
{
    public class GetUserRolesHandler : IRequestHandler<GetUserRoles, BaseApiResponse<IEnumerable<RoleTypeEnum>>>
    {
        private readonly IUserService _userService;

        public GetUserRolesHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseApiResponse<IEnumerable<RoleTypeEnum>>> Handle(GetUserRoles request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserRoles(request.Id);
        }
    }
}
