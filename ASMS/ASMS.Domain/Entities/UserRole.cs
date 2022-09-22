namespace ASMS.Domain.Entities
{
    public class UserRole : AuditEntity<long>
    {
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
