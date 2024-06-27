using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class InstituteClass : AuditEntity<long>, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public long ActivityId { get; set; }

        public long PrincipalCoachId { get; set; }

        public long? AuxCoachId { get; set; }

        public long RoomId { get; set; }

        public string Description { get; set; } = string.Empty;

        public TimeOnly StartTime { get; set; }

        public TimeOnly FinishTime { get; set; }

        public bool IsRecurrence { get; set; }

        public DateTime? FromRange { get; set; }

        public DateTime? ToRange { get; set; }

        public ICollection<InstituteClassDayOfWeek>? DaysOfWeek { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Institute Institute { get; set; }

        public virtual Coach PrincipalCoach { get; set; }

        public virtual Coach? AuxCoach { get; set; }

        public virtual Room Room { get; set; }

        public ICollection<InstituteClassBlock> Blocks { get; set; } = new List<InstituteClassBlock>();
    }
}