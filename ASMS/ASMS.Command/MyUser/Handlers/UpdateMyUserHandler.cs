using ASMS.Command.MyUser.Commands;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.MyUser.Handlers
{
    public class UpdateMyUserHandler : IRequestHandler<UpdateMyUserCommand, BaseApiResponse<UserBasicDto>>
    {
        private readonly IUserService _userService;
        private readonly IUserInfoService _userInfoService;

        public UpdateMyUserHandler(IUserService userService, IUserInfoService userInfoService)
        {
            _userService = userService;
            _userInfoService = userInfoService;
        }

        public async Task<BaseApiResponse<UserBasicDto>> Handle(UpdateMyUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateMyUser(request, _userInfoService.Value!.Id);
        }
    }
}
