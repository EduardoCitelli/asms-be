namespace ASMS.DTOs.Rooms
{
    public class RoomCreateDto
    {
        public int Number { get; set; }

        public int? Floor { get; set; }

        public int MembersCapacity { get; set; }
    }
}