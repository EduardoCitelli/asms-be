using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Queries.Rooms.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Rooms.Handlers
{
    public class GetRoomComboHandler : IRequestHandler<GetRoomCombo, BaseApiResponse<IEnumerable<ComboDto<long>>>>
    {
        private readonly IRoomService _roomService;

        public GetRoomComboHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> Handle(GetRoomCombo request, CancellationToken cancellationToken)
        {
            return await _roomService.GetComboAsync();
        }
    }
}