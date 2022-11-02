namespace ASMS.Domain.Entities
{
    using ASMS.CrossCutting.Enums;

    public class Role : NameDescriptionEntity<RoleTypeEnum>
    {
        public IEnumerable<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}