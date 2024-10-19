namespace ASMS.DTOs.Payments
{
    public class PaymentSingleDto : PaymentListDto
    {
        public string MembershipName { get; set; } = string.Empty;

        public string MembershipTypeName { get; set; } = string.Empty;
    }
}