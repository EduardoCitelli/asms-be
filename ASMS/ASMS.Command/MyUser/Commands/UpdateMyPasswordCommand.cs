using ASMS.DTOs.MyUser;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.MyUser.Commands
{
    public class UpdateMyPasswordCommand : UpdateMyPasswordDto, IRequest<BaseApiResponse<bool>>
    {
    }
}
