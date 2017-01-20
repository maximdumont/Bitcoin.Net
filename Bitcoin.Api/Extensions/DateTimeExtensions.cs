using System;

namespace Bitcoin.Api.Extensions
{
    public static class DateTimeExtensions
    {
        public static int ToUnixTimestamp(this DateTime value)
        {
            return (int) Math.Truncate(value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        }

        public static DateTime ToUnixTimeStamp(this int unixTime)
        {
            return ToUnixTimeStamp((long) unixTime);
        }

        public static DateTime ToUnixTimeStamp(this long unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);
        }
    }
}