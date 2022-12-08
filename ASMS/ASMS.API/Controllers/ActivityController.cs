using ASMS.Command.Activities.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using ASMS.Queries.Activities.Requests;
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

        [HttpGet]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<PagedList<ActivityListDto>>> Get([FromQuery] GetAllActivities request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("{activityId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<ActivitySingleDto>> GetById([FromRoute] long activityId, [FromQuery] GetActivityById request)
        {
            request.Id = activityId;
            return await _mediator.Send(request);
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