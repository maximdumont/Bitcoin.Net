using System;
using Bitcoin.Api.Extensions;
using RestSharp;

namespace Bitcoin.Api.Request
{
//$timespan Duration of the chart, default is 1 year for most charts, 1 week for mempool charts. (Optional)
//$rollingAverage Duration over which the data should be averaged. (Optional)
//$start Datetime at which to start the chart. (Optional)
//$format Either JSON or CSV, defaults to JSON. (Optional)
//$sampled Boolean set to 'true' or 'false' (default 'true'). If true, limits the number of datapoints returned to ~1.5k for performance reasons. (Optional)
    public class BitcoinChartsApiRequest : IBitcoinChartsApiRequest, IEquatable<BitcoinChartsApiRequest>,
                                           IComparable<BitcoinChartsApiRequest>,ICloneable
    {
        private const string DateTimeQueryStringFormat = "yyyy-MM-dd";

        public BitcoinChartsApiRequest(TimeSpan timeSpan, TimeSpan rollingAverage, DateTime start, bool sample)
        {
            TimeSpan = timeSpan;
            RollingAverage = rollingAverage;
            Start = start;
            Sampled = sample;
        }

        public BitcoinChartsApiRequest()
        {
        }

        public TimeSpan TimeSpan { get; set; } = TimeSpan.MaxValue;
        public TimeSpan RollingAverage { get; set; } = TimeSpan.MaxValue;
        public DateTime Start { get; set; } = default(DateTime);
        public bool Sampled { get; set; } = true;

        public string ChartType { get; set; } = "market-price";

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

        public bool Equals(BitcoinChartsApiRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return TimeSpan.Equals(other.TimeSpan) && RollingAverage.Equals(other.RollingAverage) &&
                   Start.Equals(other.Start) && Sampled == other.Sampled && string.Equals(ChartType, other.ChartType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((BitcoinChartsApiRequest) obj);
        }

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

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}