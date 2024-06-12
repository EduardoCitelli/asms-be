using ASMS.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Payments
{
    public class PaymentDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, 4, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public PaymentType PaymentType { get; set; }
    }
}
