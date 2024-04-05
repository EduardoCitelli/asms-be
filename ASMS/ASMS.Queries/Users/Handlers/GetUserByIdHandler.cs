using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Queries.Users.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Users.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, BaseApiResponse<UserBasicDto>>
    {
        private static readonly RoleTypeEnum[] _administrationRoles = new[] { RoleTypeEnum.Manager, RoleTypeEnum.StaffMember, RoleTypeEnum.SuperAdmin };

        private readonly IUserService _userService;
        private readonly IUserInfoService _userInfoService;

        public GetUserByIdHandler(IUserService userService, IUserInfoService userInfoService)
        {
            _userService = userService;
            _userInfoService = userInfoService;
        }

        public async Task<BaseApiResponse<UserBasicDto>> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var loggedUser = _userInfoService.Value!;

            if (loggedUser.Roles.Intersect(_administrationRoles).Any())
                return await _userService.GetOneAsync(request.Id);

            throw new BadRequestException("User does not have authorization to get user");
        }
    }
}