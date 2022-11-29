using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Rooms.Commands
{
    public class RoomDeleteCommand : IRequest<BaseApiResponse<RoomSingleDto>>
    {
        public RoomDeleteCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}