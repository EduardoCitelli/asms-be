using ASMS.DTOs.Shared;
using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.MembershipTypes
{
    public class MembershipTypeCreateDto : NameDescriptionDto
    {
        public bool IsByQuantity { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public int MonthQuantity { get; set; }

        public int? ClassQuantity { get; set; }
    }
}
