using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.MyUser
{
    public class UpdateMyPasswordDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(7, ErrorMessage = "Field {0} must be longer than {1}")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field {0} is required")]
        public string OldPassword { get; set; } = string.Empty;
    }
}