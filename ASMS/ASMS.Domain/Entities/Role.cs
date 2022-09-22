namespace ASMS.Domain.Entities
{
    public class Role : AuditEntity<RoleTypeEnum>
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public IEnumerable<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}