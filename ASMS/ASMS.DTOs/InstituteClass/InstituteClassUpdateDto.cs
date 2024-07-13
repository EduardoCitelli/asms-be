using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASMS.DTOs.InstituteClass
{
    public class InstituteClassUpdateDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public long PrincipalCoachId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public long? AuxCoachId { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public long RoomId { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(7, ErrorMessage = "Field {0} must be longer than {1}")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public TimeOnly StartTime { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Range(30, int.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public int MinutesDuration { get; set; }

        [JsonIgnore]
        public TimeSpan ClientOffset { get; set; }
    }
}
