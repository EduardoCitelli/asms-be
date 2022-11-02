namespace ASMS.Domain.Entities
{
    public class MembershipType : NameDescriptionEntity<long>
    {
        public bool IsByQuantity { get; set; }

        public int MonthQuantity { get; set; }

        public int? ClassQuantity { get; set; }

        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    }
}