using System;
using RestSharp;

namespace Bitcoin.Api.Data
{
    public class BitcoinChartsApiExecutionContext<T> : IBitcoinChartsApiExecutionContext<T> where T : new()
    {
        private const string DefaultRoute = "https://api.blockchain.info/charts";
        private RestClient _client;

        public BitcoinChartsApiExecutionContext(Uri route)
        {
            Route = route;
        }

        public BitcoinChartsApiExecutionContext()
        {
            Route = new Uri(DefaultRoute);
        }

        public Uri Route { get; }

        public T Execute(IRestRequest request)
        {
            if (_client == null)
                _client = new RestClient {BaseUrl = Route};

            var result = _client.Execute<T>(request);

            if (result.ErrorException != null)
                throw new Exception($"Error - {result.ErrorException.Message}");

            return result.Data;
        }

        public T Execute(IBitcoinApiRequest request) => Execute(request.CreateRequest());
    }
}