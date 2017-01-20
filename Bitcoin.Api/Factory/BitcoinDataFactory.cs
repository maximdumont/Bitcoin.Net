using System;
using Bitcoin.Api.Context;
using Bitcoin.Api.Request;
using Bitcoin.Api.Response;

namespace Bitcoin.Api.Factory
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Bitcoin Data Factory to create request for given date </summary>
    ///
    /// <remarks>   Maxim, 1/19/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class BitcoinDataFactory
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets data for given date and whether or not to cap the results </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ///
        /// <param name="date"> The date Date/Time. </param>
        /// <param name="cap">  (Optional) True to capability. </param>
        ///
        /// <returns>   The data for. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static BitcoinChartsApiResponse GetDataFor(DateTime date, bool cap = true)
        {
            var apiRequest = new BitcoinChartsApiRequest
            {
                Start = date
            };
            var client = new BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>();
            return client.Execute(apiRequest.CreateRequest());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets data from today. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ///
        /// <returns>   The data from today. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static BitcoinChartsApiResponse GetDataFromToday()
        {
            return GetDataFor(DateTime.Now);
        }
    }
}