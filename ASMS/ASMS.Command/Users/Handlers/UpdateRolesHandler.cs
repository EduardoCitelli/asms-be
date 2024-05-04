using ASMS.Command.Users.Commands;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Users.Handlers
{
    public class UpdateRolesHandler : IRequestHandler<UpdateRolesCommand, BaseApiResponse<bool>>
    {
        private readonly IUserService _userService;

        public UpdateRolesHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseApiResponse<bool>> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateRolesAsync(request.Id, request.Roles);
        }
    }
}
