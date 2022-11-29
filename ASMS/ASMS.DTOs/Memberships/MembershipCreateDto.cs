using ASMS.DTOs.Shared;
using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Memberships
{
    public class MembershipCreateDto : NameDescriptionDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public long MembershipTypeId { get; set; }

        public bool IsPremium { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public decimal Price { get; set; }
    }
}