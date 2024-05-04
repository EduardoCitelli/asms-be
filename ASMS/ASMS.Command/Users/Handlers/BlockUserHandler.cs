using ASMS.Command.Users.Commands;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Users.Handlers
{
    public class BlockUserHandler : IRequestHandler<BlockUserCommand, BaseApiResponse<bool>>
    {
        private readonly IUserService _userService;

        public BlockUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseApiResponse<bool>> Handle(BlockUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.BlockUnblockUser(request.Id, true);
        }
    }
}
