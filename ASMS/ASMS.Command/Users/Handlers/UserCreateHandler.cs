using ASMS.Command.Users.Commands;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Security;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Users.Handlers
{
    public class UserCreateHandler : IRequestHandler<UserCreateCommand, BaseApiResponse<UserBasicDto>>
    {
        private readonly IUserService _userService;

        public UserCreateHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseApiResponse<UserBasicDto>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            await _userService.ValidateExistentInfo(request.UserName, request.Email);

            request.Password = request.Password.ToHash();
            request.Email = request.Email.ToLower();

            return await _userService.CreateUser(request);
        }
    }
}
