using ASMS.Command.Auths.Commands;
using ASMS.DTOs.Auth;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Auths.Handlers
{
    public class AuthLoginHandler : IRequestHandler<AuthLoginCommand, BaseApiResponse<AuthResponseDto>>
    {
        private readonly IUserService _userService;

        public AuthLoginHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseApiResponse<AuthResponseDto>> Handle(AuthLoginCommand request, CancellationToken cancellationToken)
        {
            return await _userService.LoginAsync(request);
        }
    }
}
