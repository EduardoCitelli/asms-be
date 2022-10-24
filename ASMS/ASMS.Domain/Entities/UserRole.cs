using ASMS.CrossCutting.Enums;

namespace ASMS.Domain.Entities
{
    public class UserRole : AuditEntity<long>
    {
        public RoleTypeEnum RoleId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
