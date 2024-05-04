using ASMS.Command.Users.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using ASMS.Queries.Users.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class UserController : DefaultController
    {
        public UserController(IMediator mediator, ILogger<UserController> logger)
            : base(mediator, logger)
        {
        }

        [HttpPost]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        [AllowAnonymous]
        public async Task<BaseApiResponse<UserBasicDto>> Create([FromBody] UserCreateCommand createCommand)
        {
            return await _mediator.Send(createCommand);
        }

        [HttpPut("{userId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<UserBasicDto>> Update([FromRoute] long userId, [FromBody] UpdateUserCommand request)
        {
            return await _mediator.Send(new UpdateUserCommand(request, userId));
        }

        [HttpPut("[action]/{userId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<bool>> Block([FromRoute] long userId)
        {
            return await _mediator.Send(new BlockUserCommand(userId));
        }

        [HttpPut("[action]/{userId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<bool>> Unblock([FromRoute] long userId)
        {
            return await _mediator.Send(new UnblockUserCommand(userId));
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<PagedList<UserListDto>>> Get([FromQuery] GetAllUsers request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<UserBasicDto>> GetById([FromRoute] long userId)
        {
            return await _mediator.Send(new GetUserById(userId));
        }

        [HttpGet("{userId}/roles")]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<IEnumerable<RoleTypeEnum>>> GetRoles([FromRoute] long userId)
        {
            return await _mediator.Send(new GetUserRoles(userId));
        }

        [HttpPut("{userId}/roles")]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<bool>> UpdateRoles([FromRoute] long userId, [FromBody] IEnumerable<RoleTypeEnum> roles)
        {
            return await _mediator.Send(new UpdateRolesCommand(userId, roles));
        }
    }
}