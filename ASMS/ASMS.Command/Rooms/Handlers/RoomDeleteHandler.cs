using ASMS.Command.Rooms.Commands;
using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Rooms.Handlers
{
    public class RoomDeleteHandler : IRequestHandler<RoomDeleteCommand, BaseApiResponse<RoomSingleDto>>
    {
        private readonly IRoomService _roomService;

        public RoomDeleteHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<BaseApiResponse<RoomSingleDto>> Handle(RoomDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _roomService.DeleteAsync(request.Id);
        }
    }
}