using ASMS.CrossCutting.Enums;
using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class Payment : AuditEntity<long>, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public DateTime EmittedDate { get; set; }

        public decimal Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        public virtual Institute Institute { get; set; }

        public virtual ICollection<InstituteMemberMembership> PaidMembership { get; set; } = new List<InstituteMemberMembership>();
    }
}