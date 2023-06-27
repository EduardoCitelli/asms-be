using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Users
{
    public class UserPersonalInfoDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(3, ErrorMessage = "Field {0} must be longer than {1}")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(3, ErrorMessage = "Field {0} must be longer than {1}")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(3, ErrorMessage = "Field {0} must be longer than {1}")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
