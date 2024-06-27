namespace ASMS.Domain.Entities
{
    public class InstituteMemberInstituteClassBlock : AuditEntity<long>
    {
        public long InstituteMemberId { get; set; }

        public long InstituteClassBlockId { get; set; }

        public virtual InstituteMember InstituteMember { get; set; }

        public virtual InstituteClassBlock ClassTaked { get; set; }
    }
}
