using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class InstituteMember : PersonalInfoEntity, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public bool IsEnabled { get; set; } = true;

        public virtual Institute Institute { get; set; }

        public virtual ICollection<InstituteMemberMembership> Memberships { get; set; } = new List<InstituteMemberMembership>();

        public virtual ICollection<InstituteMemberInstituteClassBlock> Classes { get; set; } = new List<InstituteMemberInstituteClassBlock>();

        public virtual ICollection<InstituteMemberNote> Notes { get; set; } = new List<InstituteMemberNote>();

        public virtual ICollection<InstituteMemberActivities> AllowedActivities { get; set; } = new List<InstituteMemberActivities>();
    }
}
