namespace ASMS.Domain.Entities
{
    public class InstituteClassDayOfWeek : BaseEntity<DayOfWeek>
    {
        public long InstituteClassId { get; set; }

        public InstituteClass InstituteClass { get; set; }
    }
}
