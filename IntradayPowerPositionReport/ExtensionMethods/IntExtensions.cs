using System;

namespace IntradayPowerPositionReport.ExtensionMethods
{
    public static class IntExtensions
    {
        /// <summary>
        /// For example, convert (int) 1 to (DateTime) 11pm from previous day
        /// </summary>
        /// <param name="valueToConvert"></param>
        /// <param name="businessDate"></param>
        /// <returns></returns>
        public static DateTime ConvertIntToLocalTime(this int periodToConvert, DateTime businessDate)
        {
            var date = new DateTime(businessDate.Year, businessDate.Month, businessDate.Day, businessDate.Hour, 0, 0, DateTimeKind.Utc);
            return date.AddHours(periodToConvert - 2);
        }
    }
}
