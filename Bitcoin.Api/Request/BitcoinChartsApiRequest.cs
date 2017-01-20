using System;
using Bitcoin.Api.Extensions;
using RestSharp;

namespace Bitcoin.Api.Request
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A bitcoin charts API request. </summary>
    /// <remarks>   Maxim, 1/19/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BitcoinChartsApiRequest : IBitcoinChartsApiRequest, IEquatable<BitcoinChartsApiRequest>,
        IComparable<BitcoinChartsApiRequest>, ICloneable
    {
        /// <summary>   The date time query string format used by bitcoin api </summary>
        private const string DateTimeQueryStringFormat = "yyyy-MM-dd";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <param name="timeSpan">         The time span. </param>
        /// <param name="rollingAverage">   The rolling average. </param>
        /// <param name="start">            The start Date/Time. </param>
        /// <param name="sample">           True to sample. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BitcoinChartsApiRequest(TimeSpan timeSpan, TimeSpan rollingAverage, DateTime start, bool sample)
        {
            TimeSpan = timeSpan;
            RollingAverage = rollingAverage;
            Start = start;
            Sampled = sample;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BitcoinChartsApiRequest()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Duration of the chart, default is 1 year for most charts, 1 week for mempool charts. (Optional) </summary>
        /// <value> The time span. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public TimeSpan TimeSpan { get; set; } = TimeSpan.MaxValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Duration over which the data should be averaged. (Optional) </summary>
        /// <value> The rolling average. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public TimeSpan RollingAverage { get; set; } = TimeSpan.MaxValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Datetime at which to start the chart. (Optional) </summary>
        /// <value> The start. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public DateTime Start { get; set; } = default(DateTime);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///     Boolean set to 'true' or 'false' (default 'true'). If true, limits the number of datapoints returned to
        ///     ~1.5k for performance reasons. (Optional)
        /// </summary>
        /// <value> True if sampled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool Sampled { get; set; } = true;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the chart. See https://blockchain.info/charts for more info </summary>
        /// <value> The type of the chart. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ChartType { get; set; } = "market-price";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates the request based on object data </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <returns>   The new request. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IRestRequest CreateRequest()
        {
            var request = new RestRequest(ChartType);

            if (Start != default(DateTime))
                request.AddQueryParameter("start", Start.ToString(DateTimeQueryStringFormat));

            if (TimeSpan != TimeSpan.MaxValue)
                request.AddQueryParameter("timeSpan", TimeSpan.ToTimeString());

            request.AddQueryParameter("sampled", Sampled ? "1" : "0");

            if (RollingAverage != TimeSpan.MaxValue)
                request.AddQueryParameter("rollingAverage", TimeSpan.ToTimeString());

            return request;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a new object that is a copy of the current instance. </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <returns>   A new object that is a copy of this instance. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public object Clone()
        {
            return MemberwiseClone();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Compares the current object with another object of the same type. </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <param name="other">    An object to compare with this object. </param>
        /// <returns>
        ///     A value that indicates the relative order of the objects being compared. The return value has
        ///     the following meanings: Value Meaning Less than zero This object is less than the
        ///     <paramref name="other" />
        ///     parameter.Zero This object is equal to <paramref name="other" />
        ///     . Greater than zero This object is greater than <paramref name="other" />
        ///     .
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public int CompareTo(BitcoinChartsApiRequest other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var timeSpanComparison = TimeSpan.CompareTo(other.TimeSpan);
            if (timeSpanComparison != 0) return timeSpanComparison;
            var rollingAverageComparison = RollingAverage.CompareTo(other.RollingAverage);
            if (rollingAverageComparison != 0) return rollingAverageComparison;
            var startComparison = Start.CompareTo(other.Start);
            if (startComparison != 0) return startComparison;
            var sampledComparison = Sampled.CompareTo(other.Sampled);
            if (sampledComparison != 0) return sampledComparison;
            return string.Compare(ChartType, other.ChartType, StringComparison.Ordinal);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <param name="other">    An object to compare with this object. </param>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" />
        ///     parameter; otherwise, false.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool Equals(BitcoinChartsApiRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return TimeSpan.Equals(other.TimeSpan) && RollingAverage.Equals(other.RollingAverage) &&
                   Start.Equals(other.Start) && Sampled == other.Sampled && string.Equals(ChartType, other.ChartType);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determines whether the specified object is equal to the current object. </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <param name="obj">  The object to compare with the current object. </param>
        /// <returns>
        ///     true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((BitcoinChartsApiRequest) obj);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TimeSpan.GetHashCode();
                hashCode = (hashCode * 397) ^ RollingAverage.GetHashCode();
                hashCode = (hashCode * 397) ^ Start.GetHashCode();
                hashCode = (hashCode * 397) ^ Sampled.GetHashCode();
                hashCode = (hashCode * 397) ^ (ChartType != null ? ChartType.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}