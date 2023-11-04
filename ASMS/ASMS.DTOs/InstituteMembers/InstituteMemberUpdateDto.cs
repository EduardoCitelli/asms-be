using ASMS.DTOs.Users;

namespace ASMS.DTOs.InstituteMembers
{
    public class InstituteMemberUpdateDto : InstituteMemberBasicDto
    {
        public long Id { get; set; }

        public UserBasicDto User { get; set; }
    }
}
