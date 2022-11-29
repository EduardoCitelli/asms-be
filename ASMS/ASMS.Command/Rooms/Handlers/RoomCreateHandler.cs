using ASMS.Command.Rooms.Commands;
using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Rooms.Handlers
{
    public class RoomCreateHandler : IRequestHandler<RoomCreateCommand, BaseApiResponse<RoomSingleDto>>
    {
        private readonly IRoomService _roomService;

        public RoomCreateHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<BaseApiResponse<RoomSingleDto>> Handle(RoomCreateCommand request, CancellationToken cancellationToken)
        {
            var numberAlreadyExist = await _roomService.AnyAsync(x => x.Number == request.Number);

            return numberAlreadyExist ? throw new BadRequestException("Room number already exist") : await _roomService.CreateAsync(request);
        }
    }
}