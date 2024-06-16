using ASMS.CrossCutting.Enums;
using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class Payment : AuditEntity<long>, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public DateTime EmittedDate { get; set; } = DateTime.UtcNow;

        public decimal Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        public long InstituteMemberMembershipId { get; set; }

        public virtual Institute Institute { get; set; }

        public virtual InstituteMemberMembership MembershipPayment { get; set; }
    }
}