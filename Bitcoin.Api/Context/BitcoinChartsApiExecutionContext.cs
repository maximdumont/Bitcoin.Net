using System;
using Bitcoin.Api.Request;
using RestSharp;

namespace Bitcoin.Api.Context
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A bitcoin charts API execution context. </summary>
    /// <remarks>   Maxim, 1/19/2017. </remarks>
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BitcoinChartsApiExecutionContext<T> : IBitcoinChartsApiExecutionContext<T> where T : new()
    {
        /// <summary>   Default Bitcoin Api Route. </summary>
        private const string DefaultRoute = "https://api.blockchain.info/charts";


        /// <summary>   RestSharp Rest Client For Executing Calls. </summary>
        private RestClient _client;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <param name="route"> Override the default router if the API URI is different </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BitcoinChartsApiExecutionContext(Uri route)
        {
            Route = route;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor uses DefaultRouter </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BitcoinChartsApiExecutionContext()
        {
            Route = new Uri(DefaultRoute);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the route set in constructor </summary>
        /// <value> The route. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Uri Route { get; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the given request and return a mapped data type </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /// <param name="request">  The request. </param>
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public T Execute(IRestRequest request)
        {
            if (_client == null)
                _client = new RestClient {BaseUrl = Route};

            var result = _client.Execute<T>(request);

            if (result.ErrorException != null)
                throw new Exception($"Error - {result.ErrorException.Message}");

            return result.Data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///     Executes the given request and return a mapped data type. Uses CreateRequest to create request based on
        ///     impelementation
        /// </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <param name="request">  The request. </param>
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public T Execute(IBitcoinChartsApiRequest request) => Execute(request.CreateRequest());

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Attempts to execute from the given data  </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <param name="request">  The request. </param>
        /// <param name="result">   [out] The result. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static bool TryExecute(BitcoinChartsApiRequest request, out T result)
            => TryExecute(request.CreateRequest(), out result);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Attempts to execute from the given data. </summary>
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        /// <param name="request">  The request. </param>
        /// <param name="result">   [out] The result. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
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