﻿using ASMS.Command.Memberships.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class MembershipController : DefaultController
    {
        public MembershipController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<MembershipSingleDto>> Create([FromBody] MembershipCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{membershipId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<MembershipSingleDto>> Update([FromRoute] long membershipId, [FromBody] MembershipUpdateCommand command)
        {
            command.Id = membershipId;
            return await _mediator.Send(command);
        }

        [HttpDelete("{membershipId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<MembershipSingleDto>> Delete([FromRoute] long membershipId)
        {
            var command = new MembershipDeleteCommand(membershipId);
            return await _mediator.Send(command);
        }
    }
}