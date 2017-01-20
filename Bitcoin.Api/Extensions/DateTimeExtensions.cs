using System;

namespace Bitcoin.Api.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Extensions For DateTime </summary>
    ///
    /// <remarks>   Maxim, 1/19/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class DateTimeExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A DateTime extension method that converts a datetime value to an unix timestamp.
        /// </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ///
        /// <param name="value">    The value to act on. </param>
        ///
        /// <returns>   Value as an int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int ToUnixTimestamp(this DateTime value)
        {
            return (int) Math.Truncate(value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// An int extension method that converts an integer to an integer to unix time stamp.
        /// </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ///
        /// <param name="unixTime"> The unixTime to act on. </param>
        ///
        /// <returns>   UnixTime as a DateTime. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTime ToUnixTimeStamp(this int unixTime)
        {
            return ToUnixTimeStamp((long) unixTime);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An int extension method that converts a double to an unix time stamp. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ///
        /// <param name="unixTime"> The unixTime to act on. </param>
        ///
        /// <returns>   UnixTime as a DateTime. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTime ToUnixTimeStamp(this long unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);
        }
    }
}