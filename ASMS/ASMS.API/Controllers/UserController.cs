using ASMS.Command.Users.Requests;
using ASMS.CrossCutting.Enums;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class UserController : DefaultController
    {
        public UserController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<UserBasicDto>> Create([FromBody] UserCreateCommand createCommand)
        {
            return await _mediator.Send(createCommand);
        }
    }
}