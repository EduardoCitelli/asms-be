using ASMS.Command.Activities.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Activities;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Queries.Activities.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class ActivityController : DefaultController
    {
        public ActivityController(IMediator mediator, ILogger<ActivityController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<BaseApiResponse<PagedList<ActivityListDto>>> Get([FromQuery] GetAllActivities request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("{activityId}")]
        public async Task<BaseApiResponse<ActivitySingleDto>> GetById([FromRoute] long activityId)
        {
            return await _mediator.Send(new GetActivityById(activityId));
        }

        [HttpGet("combos")]
        public async Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> Combo()
        {
            return await _mediator.Send(new GetAllActivitiesForCombo());
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