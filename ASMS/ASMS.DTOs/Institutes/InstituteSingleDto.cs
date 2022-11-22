using ASMS.DTOs.Users;

namespace ASMS.DTOs.Institutes
{
    public class InstituteSingleDto : InstituteUpdateDto
    {
        public UserBasicDto User { get; set; } = new UserBasicDto();
    }
}
