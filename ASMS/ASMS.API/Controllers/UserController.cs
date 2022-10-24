using ASMS.Command.Users.Requests;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidateModelAttribute))]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<BaseApiResponse<UserBasicDto>> Create([FromBody] UserCreateCommand createCommand)
        {
            return await _mediator.Send(createCommand);
        }
    }
}
