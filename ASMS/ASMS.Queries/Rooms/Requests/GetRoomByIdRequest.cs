using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using MediatR;
using System.Text.Json.Serialization;

namespace ASMS.Queries.Rooms.Requests
{
    public class GetRoomByIdRequest : IRequest<BaseApiResponse<RoomSingleDto>>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}