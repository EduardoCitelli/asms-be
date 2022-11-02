namespace ASMS.Domain.Entities
{
    public class InstituteMemberActivities : AuditEntity<long>
    {
        public long ActivityId { get; set; }

        public long InstituteMemberId { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual InstituteMember InstituteMember { get; set; }
    }
}