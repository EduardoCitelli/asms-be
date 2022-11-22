using ASMS.DTOs.Auth;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Auths.Commands
{
    public class AuthLoginCommand : AuthLoginDto, IRequest<BaseApiResponse<AuthResponseDto>>
    {
    }
}
