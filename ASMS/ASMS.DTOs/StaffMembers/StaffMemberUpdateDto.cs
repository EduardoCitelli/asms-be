using ASMS.DTOs.Users;

namespace ASMS.DTOs.StaffMembers
{
    public class StaffMemberUpdateDto : StaffMemberBasicDto
    {
        public long Id { get; set; }

        public UserBasicDto User { get; set; }
    }
}