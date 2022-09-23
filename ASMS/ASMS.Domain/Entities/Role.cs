namespace ASMS.Domain.Entities
{
    using ASMS.CrossCutting.Enums;

    public class Role : AuditEntity<RoleTypeEnum>
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public IEnumerable<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}