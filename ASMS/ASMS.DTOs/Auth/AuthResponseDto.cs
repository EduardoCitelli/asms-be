using ASMS.CrossCutting.Enums;
using ASMS.DTOs.Users;

namespace ASMS.DTOs.Auth
{
    public class AuthResponseDto : UserBasicDto
    {
        public string Token { get; set; } = string.Empty;

        public IEnumerable<RoleTypeEnum> Roles { get; set; } = new List<RoleTypeEnum>();
    }
}