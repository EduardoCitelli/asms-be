using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Shared
{
    public abstract class NameDescriptionDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(3, ErrorMessage = "Field {0} must be longer than {1}")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(6, ErrorMessage = "Field {0} must be longer than {1}")]
        public string Description { get; set; } = string.Empty;
    }
}