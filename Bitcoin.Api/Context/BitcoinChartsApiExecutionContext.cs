using System;
using Bitcoin.Api.Request;
using RestSharp;

namespace Bitcoin.Api.Context
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

        public static bool TryExecute(IBitcoinApiRequest request, out T result)
            => TryExecute(request.CreateRequest(), out result);

        public static bool TryExecute(IRestRequest request, out T result)
        {
            result = default(T);
            var isSuccess = true;

            var client = new BitcoinChartsApiExecutionContext<T>();

            try
            {
                result = client.Execute(request);
            }
            catch (Exception exception)
            {
                isSuccess = false;
            }

            return isSuccess;
        }
    }
}