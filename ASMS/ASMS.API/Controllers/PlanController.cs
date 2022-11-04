using ASMS.Command.Plans.Request;
using ASMS.CrossCutting.Extensions;
using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class PlanController : DefaultController
    {
        public PlanController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public Task<BaseApiResponse<PlanSingleDto>> CreatePlan([FromBody] PlanCreateCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut("{planId}")]
        public Task<BaseApiResponse<PlanSingleDto>> UpdatePlan([FromRoute] int planId, [FromBody] PlanCreateCommand command)
        {
            var updateCommand = DtoMapperExtension.MapTo<PlanUpdateCommand>(command);
            updateCommand.Id = planId;

            return _mediator.Send(updateCommand);
        }

        [HttpDelete("planId")]
        public Task<BaseApiResponse<PlanSingleDto>> DeletePlan([FromRoute] int planId)
        {
            return _mediator.Send(new PlanDeleteCommand(planId));
        }
    }
}