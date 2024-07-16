using ASMS.CrossCutting.Utils.Models;
using System.Text.Json.Serialization;

namespace ASMS.DTOs.Shared
{
    public class PagedFilterRequestDto : PagedRequestDto
    {
        public string Filter { get; set; } = string.Empty;

        [JsonIgnore]
        public RootFilter? RootFilter { get; set; }
    }
}
