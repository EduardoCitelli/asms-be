using ASMS.DTOs.Shared;
using System.ComponentModel.DataAnnotations;

namespace ASMS.DTOs.Rooms
{
    public class RoomCreateDto : NameDescriptionDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public int Number { get; set; }

        public int? Floor { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Field {0} must be greater than {1} and less than {2}")]
        public int MembersCapacity { get; set; }
    }
}