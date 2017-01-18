using System;
using Bitcoin.Api.Data;

namespace Project_S.Bitcoin.Factory
{
    public class BitcoinDataFactory
    {
        public static BitcoinChartsApiResponse GetDataFor(DateTime date, bool cap = true)
        {
            var apiRequest = new BitcoinChartsApiRequest
            {
                Start = date,
                LimitTo1500 = cap
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