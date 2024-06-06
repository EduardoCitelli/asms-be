using System.Text.Json.Serialization;

namespace ASMS.DTOs.InstituteMembers
{
    public class UpdateStatusInstituteMemberDto
    {
        [JsonIgnore]
        public long Id { get; set; }

        public bool IsEnabled { get; set; }
    }
}