using System;

namespace Bitcoin.Api.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   TimeSpan Extensions  </summary>
    ///
    /// <remarks>   Maxim, 1/19/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class TimeSpanExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A TimeSpan extension method that converts an input to a time string. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ///
        /// <param name="input">    The input to act on. </param>
        ///
        /// <returns>   Input as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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