namespace ASMS.Domain.Entities
{
    public class Institute : PersonalInfoEntity
    {
        public string InstitutionName { get; set; } = string.Empty;

        public bool IsEnabled { get; set; }

        public virtual ICollection<InstitutePlan> InstitutePlans { get; set; } = new List<InstitutePlan>();

        public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();

        public virtual ICollection<InstituteMember> InstituteMembers { get; set; } = new List<InstituteMember>();

        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

        public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

        public virtual ICollection<StaffMember> StaffMembers { get; set; } = new List<StaffMember>();

        public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();

        public virtual ICollection<MembershipType> MembershipTypes { get; set; } = new List<MembershipType>();

        public virtual ICollection<InstituteClass> InstituteClasses { get; set; } = new List<InstituteClass>();

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
