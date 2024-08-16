namespace ASMS.Domain.Entities
{
    public partial class InstituteClassBlock
    {
        public long ActivityId => Header.ActivityId;

        public Activity Activity => Header.Activity;
    }
}
