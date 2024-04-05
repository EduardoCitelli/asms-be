namespace ASMS.DTOs.Users
{
    public class UserListDto : UserBasicDto
    {
        public long Id { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public bool IsBlocked { get; set; }
    }
}
