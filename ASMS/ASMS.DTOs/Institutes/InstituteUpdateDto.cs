using ASMS.DTOs.Shared;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASMS.DTOs.Institutes
{
    public class InstituteUpdateDto : InstituteBasicDto
    {
        [JsonIgnore]
        public long Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public PersonalInfoDto PersonalInfo { get; set; }
    }
}
