namespace ASMS.DTOs.Coaches
{
    using ASMS.DTOs.Users;

    public class CoachUpdateDto : CoachBasicDto
    {
        public long Id { get; set; }

        public UserBasicDto User { get; set; }
    }
}
