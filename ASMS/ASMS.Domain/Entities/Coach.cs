using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class Coach : PersonalInfoEntity, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public decimal Salary { get; set; }

        public virtual Institute Institute { get; set; }

        public ICollection<InstituteClass> PrincipalClasses { get; set; } = new List<InstituteClass>();

        public ICollection<InstituteClass> AuxClasses { get; set; } = new List<InstituteClass>();
    }
}