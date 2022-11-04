using ASMS.Command.Auths.Requests;
using ASMS.DTOs.Auth;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class AuthController : DefaultController
    {
        public AuthController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<BaseApiResponse<AuthResponseDto>> Login(AuthLoginCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}