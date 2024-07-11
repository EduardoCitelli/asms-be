namespace ASMS.Domain.Entities
{
    public partial class InstituteClassDayOfWeek
    {
        public InstituteClassDayOfWeek() { }

        public InstituteClassDayOfWeek(DayOfWeek dayofWeek)
        {
            DayOfWeek = dayofWeek;
        }
    }
}