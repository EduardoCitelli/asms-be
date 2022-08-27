namespace ASMS.Domain.Entities
{
    public class UserRole : AuditEntity<long>
    {
        public long UserId { get; set; }

        public long RoleId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
