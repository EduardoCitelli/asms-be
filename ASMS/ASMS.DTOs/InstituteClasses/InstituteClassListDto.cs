namespace ASMS.DTOs.InstituteClasses
{
    public class InstituteClassListDto
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly FinishTime { get; set; }

        public DateOnly? FromRange { get; set; }

        public DateOnly? ToRange { get; set; }

        public IEnumerable<DayOfWeek>? DaysOfWeek { get; set; }
    }
}
