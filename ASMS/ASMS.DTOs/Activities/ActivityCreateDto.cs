using ASMS.DTOs.Shared;

namespace ASMS.DTOs.Activities
{
    public class ActivityCreateDto : NameDescriptionDto
    {
        public int? MemberMinQuantity { get; set; }
    }
}