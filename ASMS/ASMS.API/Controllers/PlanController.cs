﻿using ASMS.Command.Plans.Request;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using ASMS.Queries.Plans.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class PlanController : DefaultController
    {
        public PlanController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<PagedList<PlanDto>>> GetAll([FromQuery] GetAllPlans query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("{planId}")]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<PlanSingleDto>> GetOne(int planId)
        {
            return await _mediator.Send(new GetOnePlan(planId));
        }

        [HttpPost]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<PlanSingleDto>> CreatePlan([FromBody] PlanCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{planId}")]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<PlanSingleDto>> UpdatePlan([FromRoute] int planId, [FromBody] PlanCreateCommand command)
        {
            var updateCommand = DtoMapperExtension.MapTo<PlanUpdateCommand>(command);
            updateCommand.Id = planId;

            return await _mediator.Send(updateCommand);
        }

        [HttpDelete("{planId}")]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<PlanSingleDto>> DeletePlan([FromRoute] int planId)
        {
            return await _mediator.Send(new PlanDeleteCommand(planId));
        }
    }
}