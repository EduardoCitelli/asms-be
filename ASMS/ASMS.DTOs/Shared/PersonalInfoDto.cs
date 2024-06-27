using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Shared
{
    public class PersonalInfoDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field {0} is required")]
        [MinLength(3, ErrorMessage = "Field {0} must be longer than {1}")]
        public string AddressStreet { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public int AddressNumber { get; set; }

        public string? AddressExtraInfo { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public long IdentificationNumber { get; set; }
    }
}