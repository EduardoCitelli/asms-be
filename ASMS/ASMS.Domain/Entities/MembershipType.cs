using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class MembershipType : NameDescriptionEntity<long>, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public bool IsByQuantity { get; set; }

        public int MonthQuantity { get; set; }

        public int? ClassQuantity { get; set; }

        public virtual Institute Institute { get; set; }

        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    }
}