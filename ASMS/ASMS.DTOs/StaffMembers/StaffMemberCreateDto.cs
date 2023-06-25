using ASMS.DTOs.Users;

namespace ASMS.DTOs.StaffMembers
{
    public class StaffMemberCreateDto : StaffMemberBasicDto
    {
        public UserBasicWithPasswordDto User { get; set; }
    }
}