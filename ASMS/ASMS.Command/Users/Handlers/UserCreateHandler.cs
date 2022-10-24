using ASMS.Command.Users.Requests;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
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
            await ValidateRequest(request);

            request.Password = request.Password.ToHash();
            request.Email = request.Email.ToLower();

            return await _userService.CreateUser(request);
        }

        private async Task ValidateRequest(UserCreateCommand request)
        {
            var isUserExistent = await _userService.ExistUserName(request.UserName);

            if (isUserExistent.Content)
                throw new BadRequestException($"Username {request.UserName} already exist");

            var isEmailExistent = await _userService.ExistEmail(request.Email);

            if (isEmailExistent.Content)
                throw new BadRequestException($"Email {request.Email} already exist");
        }
    }
}
