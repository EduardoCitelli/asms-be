namespace ASMS.Domain.Entities
{
    public partial class InstituteMemberMembership
    {
        public bool IsActive => !NeedToPay &&
                                LastFullPaymentDate != null &&                                
                                Payments.Where(x => x.EmittedDate.Day >= LastFullPaymentDate.Value.Day)
                                        .Sum(x => x.Amount) >= Membership.Price;

        public bool NeedToPay => ExpirationDate < DateTime.UtcNow ||
                                 RemainingClasses != null && RemainingClasses <= 0;

        public void HandleExpirationDate(bool updateSinceToday)
        {
            var month = Membership.MembershipType.MonthQuantity;
            ExpirationDate = updateSinceToday ? DateTime.UtcNow.AddMonths(month) : ExpirationDate.AddMonths(month);
        }
    }
}