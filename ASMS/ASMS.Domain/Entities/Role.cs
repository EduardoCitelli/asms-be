namespace ASMS.Domain.Entities
{
    public class Role : AuditEntity<int>
    {
        public string Name { get; set; } = string.Empty;

        public RoleTypeEnum Type { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}