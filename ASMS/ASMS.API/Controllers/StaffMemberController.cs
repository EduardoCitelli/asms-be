using ASMS.Command.StaffMembers.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class StaffMemberController : DefaultController
    {
        public StaffMemberController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<StaffMemberSingleDto>> Create([FromBody] StaffMemberCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{staffMemberId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<StaffMemberSingleDto>> Update([FromRoute] long staffMemberId, [FromBody] StaffMemberUpdateCommand command)
        {
            command.Id = staffMemberId;
            return await _mediator.Send(command);
        }

        [HttpDelete("{staffMemberId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<StaffMemberSingleDto>> Delete([FromRoute] long staffMemberId)
        {
            var command = new StaffMemberDeleteCommand(staffMemberId);
            return await _mediator.Send(command);
        }
    }
}