using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using ASMS.Queries.Rooms.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Rooms.Handlers
{
    public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdRequest, BaseApiResponse<RoomSingleDto>>
    {
        private readonly IRoomService _roomService;

        public GetRoomByIdHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<BaseApiResponse<RoomSingleDto>> Handle(GetRoomByIdRequest request, CancellationToken cancellationToken)
        {
            return await _roomService.GetOneAsync(request.Id);
        }
    }
}