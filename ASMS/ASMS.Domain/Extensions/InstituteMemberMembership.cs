namespace ASMS.Domain.Entities
{
    public partial class InstituteMemberMembership
    {
        public bool IsPaid => Payment != null;
    }
}
