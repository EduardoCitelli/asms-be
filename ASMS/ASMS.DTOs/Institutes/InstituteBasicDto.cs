using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Institutes
{
    public class InstituteBasicDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(3, ErrorMessage = "Field {0} must be longer than {1}")]
        public string InstitutionName { get; set; } = string.Empty;
    }
}