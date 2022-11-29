using ASMS.Command.Activities.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class ActivityController : DefaultController
    {
        public ActivityController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<ActivitySingleDto>> Create([FromBody] ActivityCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{activityId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<ActivitySingleDto>> Update([FromRoute] long activityId, [FromBody] ActivityUpdateCommand command)
        {
            command.Id = activityId;
            return await _mediator.Send(command);
        }

        [HttpDelete("{activityId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<ActivitySingleDto>> Delete([FromRoute] long activityId)
        {
            var command = new ActivityDeleteCommand(activityId);
            return await _mediator.Send(command);
        }
    }
}