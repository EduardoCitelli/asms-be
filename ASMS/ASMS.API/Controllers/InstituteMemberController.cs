using ASMS.Command.InstituteMembers.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using ASMS.Queries.InstituteMembers.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class InstituteMemberController : DefaultController
    {
        public InstituteMemberController(IMediator mediator, ILogger<InstituteMemberController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<PagedList<InstituteMemberListDto>>> Get([FromQuery] GetAllInstituteMember request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("{instituteMemberId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<InstituteMemberSingleDto>> GetById([FromRoute] long instituteMemberId)
        {
            return await _mediator.Send(new GetInstituteMemberById(instituteMemberId));
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<InstituteMemberSingleDto>> Create([FromBody] InstituteMemberCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{instituteMemberId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<InstituteMemberSingleDto>> Update([FromRoute] long InstituteMemberId, [FromBody] InstituteMemberUpdateCommand command)
        {
            command.Id = InstituteMemberId;
            return await _mediator.Send(command);
        }

        [HttpDelete("{instituteMemberId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<InstituteMemberSingleDto>> Delete([FromRoute] long InstituteMemberId)
        {
            var command = new InstituteMemberDeleteCommand(InstituteMemberId);
            return await _mediator.Send(command);
        }

        [HttpPut("{instituteMemberId}/status")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<bool>> UpdateStatus([FromRoute] long instituteMemberId, [FromBody] UpdateInstituteMemberStatusCommand command)
        {
            command.Id = instituteMemberId;
            return await _mediator.Send(command);
        }

        //Asignar membresia junto con el pago para dejarla activa
        //Realizar pago
    }
}
