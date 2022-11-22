using ASMS.DTOs.Shared;
using ASMS.DTOs.Users;
using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Institutes
{
    public class InstituteCreateDto : InstituteBasicDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        public PersonalInfoDto PersonalInfo { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public UserBasicWithPasswordDto User { get; set; }
    }
}