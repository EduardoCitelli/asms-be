using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Users.Commands
{
    public class UpdateUserCommand : UserUpdateDto, IRequest<BaseApiResponse<UserBasicDto>>
    {
        public UpdateUserCommand() { }
        public UpdateUserCommand(UpdateUserCommand request, long id)
        {
            Id = id;
            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email;
        }
    }
}