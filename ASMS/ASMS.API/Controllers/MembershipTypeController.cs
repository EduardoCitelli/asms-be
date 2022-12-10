using ASMS.Command.MembershipTypes.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.MembershipTypes;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Queries.MembershipTypes.Requests;
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

        [HttpGet]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<PagedList<MembershipTypeListDto>>> Get([FromQuery] GetAllMembershipTypes request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("combos")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> Combo()
        {
            return await _mediator.Send(new GetAllMembershipTypesForCombo());
        }

        [HttpGet("{membershipTypeId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<MembershipTypeSingleDto>> GetById([FromRoute] long membershipTypeId, [FromQuery] GetMembershipTypeById request)
        {
            request.Id = membershipTypeId;
            return await _mediator.Send(request);
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