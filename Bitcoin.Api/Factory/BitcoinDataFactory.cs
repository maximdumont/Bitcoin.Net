using System;
using Bitcoin.Api.Context;
using Bitcoin.Api.Request;
using Bitcoin.Api.Response;

namespace Bitcoin.Api.Factory
{
    public class BitcoinDataFactory
    {
        public static BitcoinChartsApiResponse GetDataFor(DateTime date, bool cap = true)
        {
            var apiRequest = new BitcoinChartsApiRequest
            {
                Start = date
            };
            var client = new BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>();
            return client.Execute(apiRequest.CreateRequest());
        }

        public static BitcoinChartsApiResponse GetDataFromToday()
        {
            return GetDataFor(DateTime.Now);
        }
    }
}