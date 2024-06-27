using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class Room : NameDescriptionEntity<long>, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public int Number { get; set; }

        public int? Floor { get; set; }

        public int MembersCapacity { get; set; }

        public virtual Institute Institute { get; set; }

        public virtual ICollection<InstituteClass> InstituteClasses { get; set; } = new List<InstituteClass>();

        public virtual ICollection<InstituteClassBlock> Blocks { get; set; } = new List<InstituteClassBlock>();
    }
}