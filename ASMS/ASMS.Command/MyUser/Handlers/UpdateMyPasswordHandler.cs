using ASMS.Command.MyUser.Commands;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.MyUser.Handlers
{
    public class UpdateMyPasswordHandler : IRequestHandler<UpdateMyPasswordCommand, BaseApiResponse<bool>>
    {
        private readonly IUserService _userService;
        private readonly IUserInfoService _userInfoService;

        public UpdateMyPasswordHandler(IUserService userService, IUserInfoService userInfoService)
        {
            _userService = userService;
            _userInfoService = userInfoService;
        }

        public async Task<BaseApiResponse<bool>> Handle(UpdateMyPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateMyPassword(request, _userInfoService.Value!.UserName);
        }
    }
}
