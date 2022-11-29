using ASMS.DTOs.Shared;
using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Coaches
{
    public class CoachCreateDto : PersonalInfoDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public decimal Salary { get; set; }
    }
}