using ASMS.CrossCutting.Enums;

namespace ASMS.Domain.Entities
{
    public partial class InstituteClass
    {
        public bool IsActive => Blocks.Any(x => x.ClassStatus == ClassStatus.Pending || x.ClassStatus == ClassStatus.Active);
    }
}
