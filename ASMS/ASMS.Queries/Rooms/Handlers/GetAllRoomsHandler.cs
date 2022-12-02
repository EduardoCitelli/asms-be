using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using ASMS.Queries.Rooms.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Rooms.Handlers
{
    public class GetAllRoomsHandler : IRequestHandler<GetAllRoomsRequest, BaseApiResponse<PagedList<RoomListDto>>>
    {
        private readonly IRoomService _roomService;

        public GetAllRoomsHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<BaseApiResponse<PagedList<RoomListDto>>> Handle(GetAllRoomsRequest request, CancellationToken cancellationToken)
        {
            return await _roomService.GetListAsync(request.Page, request.Size);
        }
    }
}