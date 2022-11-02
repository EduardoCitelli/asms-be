using ASMS.Domain.Abstractions;

namespace ASMS.Domain.Entities
{
    public class StaffMember : PersonalInfoEntity, IIsInstituteEntity
    {
        public long InstituteId { get; set; }

        public virtual Institute Institute { get; set; }
    }
}
