using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class Activity : NameDescriptionEntity<long>, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public int? MemberMinQuantity { get; set; }

        public virtual Institute Institute { get; set; }
    }
}