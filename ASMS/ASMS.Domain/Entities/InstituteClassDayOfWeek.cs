namespace ASMS.Domain.Entities
{
    public partial class InstituteClassDayOfWeek : BaseEntity<long>
    {
        public DayOfWeek DayOfWeek { get; set; }

        public long InstituteClassId { get; set; }

        public InstituteClass InstituteClass { get; set; }
    }
}
