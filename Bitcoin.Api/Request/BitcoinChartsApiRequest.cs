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
    public class BitcoinChartsApiRequest : IBitcoinApiRequest
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
    }
}