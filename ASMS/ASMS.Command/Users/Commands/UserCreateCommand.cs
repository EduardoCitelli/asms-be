using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Users.Commands
{
    public class UserCreateCommand : UserCreateDto, IRequest<BaseApiResponse<UserBasicDto>>
    {
    }
}