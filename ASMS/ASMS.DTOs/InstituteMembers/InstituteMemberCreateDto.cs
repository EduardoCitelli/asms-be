using ASMS.DTOs.Users;

namespace ASMS.DTOs.InstituteMembers
{
    public class InstituteMemberCreateDto : InstituteMemberBasicDto
    {
        public UserBasicWithPasswordDto User { get; set; }
    }
}
