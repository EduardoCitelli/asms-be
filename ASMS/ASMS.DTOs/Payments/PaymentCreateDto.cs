using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Payments
{
    public class PaymentCreateDto : PaymentDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public long InstituteMemberId { get; set; }

        public bool UpdateByExpirationDate { get; set; } = true;
    }
}
