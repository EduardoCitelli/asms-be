using ASMS.DTOs.Users;

namespace ASMS.DTOs.Coaches
{
    public class CoachCreateDto : CoachBasicDto
    {
        public UserBasicWithPasswordDto User { get; set; }
    }
}