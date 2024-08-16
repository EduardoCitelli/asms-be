namespace ASMS.Domain.Entities
{
    public partial class InstituteMember
    {
        public InstituteMemberMembership? ActiveMembership => Memberships.Where(x => x.IsActiveMembership)
                                                                         .FirstOrDefault();
    }
}
