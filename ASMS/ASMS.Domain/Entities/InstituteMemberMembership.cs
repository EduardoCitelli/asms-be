namespace ASMS.Domain.Entities
{
    public partial class InstituteMemberMembership : AuditEntity<long>
    {
        public long InstituteMemberId { get;set;}

        public long MembershipId { get; set; }

        public bool IsActiveMembership { get; set; } = true;

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime ExpirationDate { get; set; }

        public DateTime? LastFullPaymentDate { get; set; }

        public int? RemainingClasses { get; set; }

        public virtual InstituteMember InstituteMember { get; set; }

        public virtual Membership Membership { get; set; }

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}