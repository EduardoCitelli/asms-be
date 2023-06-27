using ASMS.DTOs.MyUser;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.MyUser.Commands
{
    public class UpdateMyUserCommand : UpdateMyUserDto, IRequest<BaseApiResponse<UserBasicDto>>
    {
    }
}
