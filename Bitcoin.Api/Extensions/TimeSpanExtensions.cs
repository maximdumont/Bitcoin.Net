using System;

namespace Bitcoin.Api.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string ToTimeString(this TimeSpan input)
        {
            var totalDays = input.Days;

            if (totalDays >= 365)
                return $"{totalDays / 365}years";

            if (totalDays >= 7)
                return $"{totalDays / 7}weeks";

            if (totalDays >= 1)
                return $"{totalDays}days";

            return $"{input.Hours}hours";
        }
    }
}