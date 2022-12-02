using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Rooms.Requests
{
    public class GetRoomByIdRequest : IRequest<BaseApiResponse<RoomSingleDto>>
    {
        public long Id { get; set; }
    }
}