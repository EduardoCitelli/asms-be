using ASMS.DTOs.Shared;

namespace ASMS.DTOs.Memberships
{
    public class MembershipComboDto : ComboDto<long>
    {
        public bool IsPremium { get; set; }

        public int? ActivityQuantity { get; set; }
    }
}