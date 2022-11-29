using ASMS.Command.MembershipTypes.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.DTOs.MembershipTypes;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class MembershipTypeController : DefaultController
    {
        public MembershipTypeController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<MembershipTypeSingleDto>> Create([FromBody] MembershipTypeCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{membershipTypeId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<MembershipTypeSingleDto>> Update([FromRoute] long membershipTypeId, [FromBody] MembershipTypeUpdateCommand command)
        {
            command.Id = membershipTypeId;
            return await _mediator.Send(command);
        }

        [HttpDelete("{membershipTypeId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<MembershipTypeSingleDto>> Delete([FromRoute] long membershipTypeId)
        {
            var command = new MembershipTypeDeleteCommand(membershipTypeId);
            return await _mediator.Send(command);
        }
    }
}