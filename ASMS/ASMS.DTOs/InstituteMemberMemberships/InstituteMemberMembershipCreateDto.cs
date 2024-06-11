using ASMS.DTOs.Payments;

namespace ASMS.DTOs.InstituteMemberMemberships
{
    public class InstituteMemberMembershipCreateDto
    {
        public long InstituteMemberId { get; set; }

        public long MembershipId { get; set; }

        public DateTime StartDate { get; set; }

        public PaymentCreateDto? Payment { get; set; }
    }
}