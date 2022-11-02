namespace ASMS.Domain.Entities
{
    public class InstituteMemberInstituteClass : AuditEntity<long>
    {
        public long InstituteMemberId { get; set; }

        public long InstituteClassId { get; set; }

        public virtual InstituteMember InstituteMember { get; set; }

        public virtual InstituteClass InstituteClass { get; set; }
    }
}
