namespace ASMS.DTOs.Coaches
{
    using ASMS.DTOs.Shared;
    using System.ComponentModel.DataAnnotations;

    public abstract class CoachBasicDto
    {
        public virtual PersonalInfoDto PersonalInfo { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public decimal Salary { get; set; }
    }
}
