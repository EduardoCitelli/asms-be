using ASMS.DTOs.Shared;

namespace ASMS.DTOs.Rooms
{
    public class RoomListDto : NameDescriptionDto
    {
        public long Id { get; set; }

        public int Number { get; set; }
    }
}
