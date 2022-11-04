using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Plans
{
    public class PlanCreateDto : PlanDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public int AllowedUsers { get; set; }

        public bool HasOnlineClasses { get; set; }
    }
}
