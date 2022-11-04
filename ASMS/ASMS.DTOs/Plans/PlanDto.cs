using ASMS.DTOs.Shared;
using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Plans
{
    public class PlanDto : NameDescriptionDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public decimal Price { get; set; }
    }
}
