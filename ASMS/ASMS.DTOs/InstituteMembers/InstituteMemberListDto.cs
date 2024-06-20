namespace ASMS.DTOs.InstituteMembers
{
    public class InstituteMemberListDto
    {
        public long Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public bool? NeedToPayMembership {  get; set; }

        public bool HasMembership { get; set; }
    }
}
