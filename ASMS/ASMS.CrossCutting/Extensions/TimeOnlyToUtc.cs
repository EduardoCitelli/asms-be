namespace ASMS.CrossCutting.Extensions
{
    public static class TimeOnlyExtensions
    {
        public static TimeOnly AddOffset(this TimeOnly time, TimeSpan offset)
        {
            var newHour = time.Hour + offset.Hours;
            var newMinute = time.Minute + offset.Minutes;

            if (newMinute >= 60)
            {
                newHour += 1;
                newMinute -= 60;
            }

            if (newHour >= 24)
                newHour -= 24;
            
            return new TimeOnly(newHour, newMinute);
        }
    }
}
