using ASMS.CrossCutting.Enums;
using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class InstituteClass : AuditEntity<long>, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public ClassStatus ClassStatus { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Institute Institute { get; set; }

        public virtual Coach PrincipalCoach { get; set; }

        public virtual Coach? AuxCoach { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<InstituteMemberInstituteClass> InstituteMembers { get; set; } = new List<InstituteMemberInstituteClass>();
    }
}