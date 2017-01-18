using System;
using System.Collections.Generic;
using RestSharp;

namespace Bitcoin.Api.Data
{
    //$timespan Duration of the chart, default is 1 year for most charts, 1 week for mempool charts. (Optional)
    //$rollingAverage Duration over which the data should be averaged. (Optional)
    //$start Datetime at which to start the chart. (Optional)
    //$format Either JSON or CSV, defaults to JSON. (Optional)
    //$sampled Boolean set to 'true' or 'false' (default 'true'). If true, limits the number of datapoints returned to ~1.5k for performance reasons. (Optional)

    public class BitcoinChartsApiRequest : IBitcoinApiRequest
    {
        private Dictionary<string, object> _requestValues;
        public string DateTimeQueryStringFormat { get; set; } = "yyyy-MM-dd";
        public TimeSpan TimeSpan { get; set; } = new TimeSpan(180, 0, 0, 0);
        public TimeSpan RollingAverage { get; set; } = new TimeSpan(180, 0, 0, 0);
        public DateTime Start { get; set; } = DateTime.Now.AddYears(-1);
        public string Format { get; set; } = "json";
        public bool LimitTo1500 { get; set; } = true;

        public Dictionary<string, object> RequestValues
            => _requestValues ?? (_requestValues = new Dictionary<string, object>());

        public string ChartType { get; set; } = "market-price";

        public IRestRequest CreateRequest()
        {
            PopulateQueryStringDictionary();

            var request = new RestRequest(ChartType);

            foreach (var requestValue in RequestValues)
                request.AddQueryParameter(requestValue.Key, (string) requestValue.Value);

            return request;
        }

        private void PopulateQueryStringDictionary()
        {
            RequestValues["timespan"] = $"{TimeSpan.Days}days";

            if (!(RollingAverage == TimeSpan.MaxValue))
                RequestValues["rollingAverage"] = $"{RollingAverage.Hours}hours";

            RequestValues["start"] = Start.ToString(DateTimeQueryStringFormat);
            RequestValues["format"] = Format;
            RequestValues["scale"] = LimitTo1500 ? "1" : "0";
        }
    }
}