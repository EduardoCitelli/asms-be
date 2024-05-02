using ASMS.Command.MyUser.Commands;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    [Authorize]
    public class MyUserController : DefaultController
    {
        public MyUserController(IMediator mediator, ILogger<MyUserController> logger)
            : base(mediator, logger)
        {
        }

        [HttpPut]
        public async Task<BaseApiResponse<UserBasicDto>> UpdateMyUser([FromBody] UpdateMyUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("password")]
        public async Task<BaseApiResponse<bool>> UpdatePassword([FromBody] UpdateMyPasswordCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
