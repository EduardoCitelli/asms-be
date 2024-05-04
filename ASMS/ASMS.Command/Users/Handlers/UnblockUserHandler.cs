using ASMS.Command.Users.Commands;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Users.Handlers
{
    public class UnblockUserHandler : IRequestHandler<UnblockUserCommand, BaseApiResponse<bool>>
    {
        private readonly IUserService _userService;

        public UnblockUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseApiResponse<bool>> Handle(UnblockUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.BlockUnblockUser(request.Id, false);
        }
    }
}