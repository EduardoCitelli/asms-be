using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Users.Commands
{
    public class UpdateUserCommand : UserUpdateDto, IRequest<BaseApiResponse<UserBasicDto>>
    {
        public UpdateUserCommand(long id)
        {
            Id = id;
        }
    }
}
