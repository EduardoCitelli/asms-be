using ASMS.Command.Rooms.Commands;
using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Rooms.Handlers
{
    public class RoomUpdateHandler : IRequestHandler<RoomUpdateCommand, BaseApiResponse<RoomSingleDto>>
    {
        private readonly IRoomService _roomService;

        public RoomUpdateHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<BaseApiResponse<RoomSingleDto>> Handle(RoomUpdateCommand request, CancellationToken cancellationToken)
        {
            var numberAlreadyExist = await _roomService.AnyAsync(x => x.Number == request.Number && x.Id != request.Id);

            return numberAlreadyExist ? throw new BadRequestException("Room number already exist") : await _roomService.UpdateAsync(request);
        }
    }
}