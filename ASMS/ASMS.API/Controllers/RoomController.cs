﻿using ASMS.Command.Rooms.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class RoomController : DefaultController
    {
        public RoomController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<RoomSingleDto>> Create([FromBody] RoomCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{roomId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<RoomSingleDto>> Update([FromRoute] long roomId, [FromBody] RoomUpdateCommand command)
        {
            command.Id = roomId;
            return await _mediator.Send(command);
        }

        [HttpDelete("{roomId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<RoomSingleDto>> Delete([FromRoute] long roomId)
        {
            var command = new RoomDeleteCommand(roomId);
            return await _mediator.Send(command);
        }
    }
}