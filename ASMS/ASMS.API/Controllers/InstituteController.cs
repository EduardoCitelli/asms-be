using ASMS.Command.Institutes.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class InstituteController : DefaultController
    {
        public InstituteController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<InstituteSingleDto>> Create([FromBody] InstituteCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{instituteId}")]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<InstituteSingleDto>> Update([FromRoute] long instituteId, [FromBody] InstituteUpdateCommand command)
        {
            command.Id = instituteId;
            return await _mediator.Send(command);
        }

        [HttpDelete("{instituteId}")]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<InstituteSingleDto>> Delete([FromRoute] long instituteId)
        {
            return await _mediator.Send(new InstituteDeleteCommand(instituteId));
        }
    }
}