using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class Coach : PersonalInfoEntity, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public decimal Salary { get; set; }

        public virtual Institute Institute { get; set; }

        public virtual ICollection<InstituteClass> PrincipalClasses { get; set; } = new List<InstituteClass>();

        public virtual ICollection<InstituteClass> AuxClasses { get; set; } = new List<InstituteClass>();

        public virtual ICollection<InstituteClassBlock> PrincipalBlocks { get; set; } = new List<InstituteClassBlock>();

        public virtual ICollection<InstituteClassBlock> AuxBlocks { get; set; } = new List<InstituteClassBlock>();
    }
}