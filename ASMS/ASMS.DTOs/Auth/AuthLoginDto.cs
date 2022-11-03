using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Auth
{
    public class AuthLoginDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(3, ErrorMessage = "Field {0} must be longer than {1}")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(3, ErrorMessage = "Field {0} must be longer than {1}")]
        public string Password { get; set; } = string.Empty;
    }
}
