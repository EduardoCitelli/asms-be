using ASMS.Command.StaffMembers.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using ASMS.Queries.StaffMembers.Requests;
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

        [HttpGet]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<PagedList<StaffMemberListDto>>> Get([FromQuery] GetAllStaffMembers request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("{staffMemberId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<StaffMemberSingleDto>> GetById([FromRoute] long staffMemberId)
        {
            return await _mediator.Send(new GetStaffMemberById(staffMemberId));
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