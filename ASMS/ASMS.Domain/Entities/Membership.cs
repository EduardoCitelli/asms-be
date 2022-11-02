using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class Membership : NameDescriptionEntity<long>, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public long MembershipTypeId { get; set; }

        public bool IsPremium { get; set; }

        public decimal Price { get; set; }

        public virtual MembershipType MembershipType { get; set; }

        public virtual Institute Institute { get; set; }
    }
}