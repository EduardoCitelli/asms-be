using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Persistence
{
    public partial class ASMSDbContext
    {
        public virtual DbSet<Activity> Activities => Set<Activity>();
        public virtual DbSet<Coach> Coaches => Set<Coach>();
        public virtual DbSet<Institute> Institutes => Set<Institute>();
        public virtual DbSet<InstituteClass> InstituteClasses => Set<InstituteClass>();
        public virtual DbSet<InstituteMember> InstitutesMembers => Set<InstituteMember>();
        public virtual DbSet<InstituteMemberActivities> InstituteMemberActivities => Set<InstituteMemberActivities>();
        public virtual DbSet<InstituteMemberInstituteClass> InstituteMemberInstituteClasses => Set<InstituteMemberInstituteClass>();
        public virtual DbSet<InstituteMemberMembership> InstituteMemberMemberships => Set<InstituteMemberMembership>();
        public virtual DbSet<InstituteMemberNote> InstituteMemberNotes => Set<InstituteMemberNote>();
        public virtual DbSet<InstitutePlan> InstitutePlans => Set<InstitutePlan>();
        public virtual DbSet<Membership> Memberships => Set<Membership>();
        public virtual DbSet<MembershipType> MembershipTypes => Set<MembershipType>();
        public virtual DbSet<NoteFile> NoteFiles => Set<NoteFile>();
        public virtual DbSet<Payment> Payments => Set<Payment>();
        public virtual DbSet<Plan> Plans => Set<Plan>();
        public virtual DbSet<Role> Roles => Set<Role>();
        public virtual DbSet<Room> Rooms => Set<Room>();
        public virtual DbSet<StaffMember> StaffMembers => Set<StaffMember>();
        public virtual DbSet<User> Users => Set<User>();
        public virtual DbSet<UserRole> UserRoles => Set<UserRole>();
    }
}