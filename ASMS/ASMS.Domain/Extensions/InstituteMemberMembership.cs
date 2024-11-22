﻿namespace ASMS.Domain.Entities
{
    public partial class InstituteMemberMembership
    {
        public bool HasExpiredClasses => RemainingClasses != null && RemainingClasses <= 0;

        public bool IsExpired => ExpirationDate < DateTime.UtcNow || HasExpiredClasses;

        public decimal PaymentForCurrentPeriod => LastFullPaymentDate == null || IsExpired  ? 0 :
                                                  Payments.Where(x => x.EmittedDate.Day >= LastFullPaymentDate.Value.Day)
                                                          .Sum(x => x.Amount);

        public bool AlreadyPaid => PaymentForCurrentPeriod >= Membership.Price;

        public bool NeedToPay => IsExpired || !AlreadyPaid;

        public decimal RemainingPayment => Membership.Price - PaymentForCurrentPeriod;

        public void HandleExpirationDate(bool updateByExpirationDate)
        {
            var month = Membership.MembershipType.MonthQuantity;
            ExpirationDate = updateByExpirationDate ? ExpirationDate.AddMonths(month) : DateTime.UtcNow.AddMonths(month);
        }
    }
}