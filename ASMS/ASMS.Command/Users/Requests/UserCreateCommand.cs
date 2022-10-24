using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Users.Requests
{
    public class UserCreateCommand : UserCreateDto, IRequest<BaseApiResponse<UserBasicDto>>
    {
    }
}