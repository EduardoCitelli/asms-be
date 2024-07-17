namespace ASMS.DTOs.InstituteClassBlocks
{
    public class InstituteClassBlockSingleDto : InstituteClassBlockListDto
    {
        public string? AuxCoachName { get; set; }

        public string RoomName { get; set; } = string.Empty;

        public string ActivityName { get; set; } = string.Empty;
    }
}