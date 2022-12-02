using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Rooms;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Rooms.Requests
{
    public class GetAllRoomsRequest : PagedRequestDto, IRequest<BaseApiResponse<PagedList<RoomListDto>>>
    {
    }
}
