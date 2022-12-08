using ASMS.DTOs.Rooms;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Rooms.Requests
{
    public class GetRoomByIdRequest : EntityByIdRequest<long>, IRequest<BaseApiResponse<RoomSingleDto>>
    {
    }
}