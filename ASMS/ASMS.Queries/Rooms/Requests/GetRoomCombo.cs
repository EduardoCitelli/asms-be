using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Rooms.Requests
{
    public class GetRoomCombo : IRequest<BaseApiResponse<IEnumerable<ComboDto<long>>>>
    {
    }
}
