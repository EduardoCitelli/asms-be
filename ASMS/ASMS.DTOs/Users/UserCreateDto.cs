using ASMS.CrossCutting.Enums;

namespace ASMS.DTOs.Users
{
    public class UserCreateDto : UserBasicWithPasswordDto
    {
        public IEnumerable<RoleTypeEnum> Roles { get; set; } = new List<RoleTypeEnum>();
    }
}
