using ASMS.CrossCutting.Enums;
using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class InstituteClassBlock : AuditEntity<long>, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public long InstituteClassId { get; set; }

        public long PrincipalCoachId { get; set; }

        public long? AuxCoachId { get; set; }

        public long RoomId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public ClassStatus ClassStatus { get; set; }

        public virtual Institute Institute { get; set; }

        public InstituteClass Header { get; set; }

        public virtual Coach PrincipalCoach { get; set; }

        public virtual Coach? AuxCoach { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<InstituteMemberInstituteClassBlock> InstituteMembers { get; set; } = new List<InstituteMemberInstituteClassBlock>();
    }
}
