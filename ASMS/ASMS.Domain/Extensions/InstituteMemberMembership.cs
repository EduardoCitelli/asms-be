namespace ASMS.Domain.Entities
{
    public partial class InstituteMemberMembership
    {
        public bool IsPaid => Payments != null &&
                              LastPaymentDate != null &&
                              ExpirationDate > DateTime.UtcNow &&
                              Payments.Sum(x => x.Amount) >= Membership.Price &&
                              Payments.Any(x => x.EmittedDate.Day == LastPaymentDate.Value.Day);

        public void HandleExpirationDate(bool updateSinceToday)
        {
            var month = Membership.MembershipType.MonthQuantity;
            ExpirationDate = updateSinceToday ? DateTime.UtcNow.AddMonths(month) : ExpirationDate.AddMonths(month);
        }
    }
}