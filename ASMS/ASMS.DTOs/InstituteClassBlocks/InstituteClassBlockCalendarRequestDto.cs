using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.InstituteClassBlocks
{
    public class InstituteClassBlockCalendarRequestDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public long RoomId { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public DateTime To { get; set; }
    }
}
