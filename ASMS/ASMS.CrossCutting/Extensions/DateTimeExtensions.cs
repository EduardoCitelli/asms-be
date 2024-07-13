namespace ASMS.CrossCutting.Extensions
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> GetDaysInRange(DateTime startDate, DateTime endDate, IEnumerable<DayOfWeek> daysOfWeek)
        {
            var current = startDate;

            while (current <= endDate)
            {
                if (daysOfWeek.Contains(current.DayOfWeek))
                    yield return current;

                current = current.AddDays(1);
            }
        }

        public static DateTime SetTime(this DateTime date, TimeOnly time)
        {
            return date.Date + time.ToTimeSpan();
        }

        public static DateTime AddOffset(this DateTime date, TimeSpan time)
        {
            return date + time;
        }

        public static DateTime RemoveOffset(this DateTime date, TimeSpan time)
        {
            return date - time;
        }
    }
}
