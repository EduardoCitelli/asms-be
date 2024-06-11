using ASMS.CrossCutting.Enums;

namespace ASMS.DTOs.Payments
{
    public class PaymentDto
    {
        public decimal Amount { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}
