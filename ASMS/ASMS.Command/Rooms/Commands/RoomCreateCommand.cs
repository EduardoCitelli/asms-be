using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Rooms.Commands
{
    public class RoomCreateCommand : RoomCreateDto, IRequest<BaseApiResponse<RoomSingleDto>>
    {
    }
}