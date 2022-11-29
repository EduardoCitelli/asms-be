using ASMS.Command.Coaches.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class CoachController : DefaultController
    {
        public CoachController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<CoachSingleDto>> Create(CoachCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{coachId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<CoachSingleDto>> Update([FromRoute] long coachId, CoachUpdateCommand coachUpdateCommand)
        {
            coachUpdateCommand.Id = coachId;
            return await _mediator.Send(coachUpdateCommand);
        }

        [HttpDelete("{coachId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<CoachSingleDto>> Delete([FromRoute] long coachId)
        {
            var command = new CoachDeleteCommand(coachId);
            return await _mediator.Send(command);
        }
    }
}