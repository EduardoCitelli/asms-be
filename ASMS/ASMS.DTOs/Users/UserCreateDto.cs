using ASMS.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Users
{
    public class UserCreateDto : UserBasicDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(7, ErrorMessage = "Field {0} must be longer than {1}")]
        public string Password { get; set; } = string.Empty;

        public IEnumerable<RoleTypeEnum> Roles { get; set; } = new List<RoleTypeEnum>();
    }
}
