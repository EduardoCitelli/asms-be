using ASMS.Command.Rooms.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Rooms;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Queries.Coaches.Requests;
using ASMS.Queries.Rooms.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class RoomController : DefaultController
    {
        public RoomController(IMediator mediator, ILogger<RoomController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<PagedList<RoomListDto>>> Get([FromQuery] GetAllRoomsRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("{roomId}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<RoomSingleDto>> GetById([FromRoute] long roomId)
        {
            return await _mediator.Send(new GetRoomByIdRequest(roomId));
        }

        [HttpGet("combos")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> GetCombos()
        {
            return await _mediator.Send(new GetRoomCombo());
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
