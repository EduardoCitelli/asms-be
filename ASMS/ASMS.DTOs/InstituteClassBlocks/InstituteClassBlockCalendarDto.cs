namespace ASMS.DTOs.InstituteClassBlocks
{
    public class InstituteClassBlockCalendarDto : InstituteClassBlockListDto
    {
        public IEnumerable<long> MemberIds { get; set; } = new List<long>();

        public int RoomCapacity { get; set; }

        public bool IsAlreadyInClass { get; set; }
    }
}
