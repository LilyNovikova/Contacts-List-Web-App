using System;

namespace ContactsWebApp.AutoTests.Utils
{
    public static class DateUtils
    {
        public static DateTime GetToday(string timezone = null)
        {
            var todayTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timezone));
            return new DateTime(todayTime.Year, todayTime.Month, todayTime.Day);
        }
    }
}
