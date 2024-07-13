using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.InstituteClass
{
    public class InstituteClassCreateDto : InstituteClassUpdateDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public long ActivityId { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public bool IsRecurrence { get; set; }

        public DateTime? NotRecurrenceDate { get; set; }

        public DateTime? FromRange { get; set; }

        public DateTime? ToRange { get; set; }

        public ICollection<DayOfWeek>? DaysOfWeek { get; set; }
    }
}