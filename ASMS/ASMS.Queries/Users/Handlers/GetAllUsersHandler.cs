using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using ASMS.Queries.Users.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Users.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, BaseApiResponse<PagedList<UserListDto>>>
    {
        private static readonly RoleTypeEnum[] _administrationRoles = new[] { RoleTypeEnum.Manager, RoleTypeEnum.StaffMember, RoleTypeEnum.SuperAdmin };

        private readonly IUserService _userService;
        private readonly IUserInfoService _userInfoService;

        public GetAllUsersHandler(IUserService userService, IUserInfoService userInfoService)
        {
            _userService = userService;
            _userInfoService = userInfoService;
        }

        public async Task<BaseApiResponse<PagedList<UserListDto>>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var user = _userInfoService.Value!;

            if (!user.Roles.Intersect(_administrationRoles).Any())
                return new BaseApiResponse<PagedList<UserListDto>>();

            return await _userService.GetListAsync(request.Page, request.Size);
        }
    }
}
