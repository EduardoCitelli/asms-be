using ASMS.DTOs.Payments;
using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.InstituteMemberMemberships
{
    public class InstituteMemberMembershipCreateDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public long InstituteMemberId { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public long MembershipId { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public DateTime StartDate { get; set; }

        public PaymentDto? Payment { get; set; }

        public IEnumerable<long>? Activities { get; set; }
    }
}