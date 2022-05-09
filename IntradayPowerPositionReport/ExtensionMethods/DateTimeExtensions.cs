using System;

namespace IntradayPowerPositionReport.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        public static bool IsHoliday (this DateTime dateToCheck)
        {
            // simple non business day check.
            if (dateToCheck.DayOfWeek == DayOfWeek.Sunday || dateToCheck.DayOfWeek == DayOfWeek.Saturday)
            {
                return true;
            }
            return false;
        }
    }
}
