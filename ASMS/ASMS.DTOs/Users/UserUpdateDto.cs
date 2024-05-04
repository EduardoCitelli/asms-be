using ASMS.DTOs.MyUser;

namespace ASMS.DTOs.Users
{
    public class UserUpdateDto : UpdateMyUserDto
    {
        public long Id { get; set; }
    }
}
