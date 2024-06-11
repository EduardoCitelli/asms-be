using ASMS.CrossCutting.Enums;

namespace ASMS.DTOs.Payments
{
    public class PaymentUpdateDto
    {
        public long Id { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}
