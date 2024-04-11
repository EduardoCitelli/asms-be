using ASMS.Command.Users.Commands;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, BaseApiResponse<UserBasicDto>>
    {
        private readonly IUserService _userService;

        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseApiResponse<UserBasicDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateMyUser(request, request.Id);
        }
    }
}
