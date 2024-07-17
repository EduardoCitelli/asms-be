using ASMS.CrossCutting.Enums;

namespace ASMS.DTOs.InstituteClassBlocks
{
    public class InstituteClassBlockListDto
    {
        public long Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public string PrincipalCoachName { get; set; } = string.Empty;

        public DateTime StartDateTime { get; set; }

        public DateTime FinishDateTime { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public ClassStatus ClassStatus { get; set; }
    }
}