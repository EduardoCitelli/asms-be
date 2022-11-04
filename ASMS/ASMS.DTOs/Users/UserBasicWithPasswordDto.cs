using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Users
{
    public class UserBasicWithPasswordDto : UserBasicDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(7, ErrorMessage = "Field {0} must be longer than {1}")]
        public string Password { get; set; } = string.Empty;
    }
}
