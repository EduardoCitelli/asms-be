namespace ASMS.DTOs.Roles
{
    using ASMS.CrossCutting.Enums;

    public class RoleListDto : RoleBasicDto
    {
        public RoleTypeEnum Id { get; set; }
    }
}
