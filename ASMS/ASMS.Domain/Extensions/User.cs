namespace ASMS.Domain.Entities
{
    public partial class User
    {
        public long? CoachInstituteId => Coach?.InstituteId;

        public long? InstituteMemberInstituteId => InstituteMember?.InstituteId;

        public long? ManagerInstituteId => Institute?.Id;

        public long? StaffMemberInstituteId => StaffMember?.InstituteId;
    }
}
