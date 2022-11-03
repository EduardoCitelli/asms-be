using ASMS.CrossCutting.Enums;

namespace ASMS.CrossCutting.Services.Models
{
    public class UserInfo
    {
        public long Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public IEnumerable<RoleTypeEnum> Roles { get; set; } = new List<RoleTypeEnum>();
    }
}