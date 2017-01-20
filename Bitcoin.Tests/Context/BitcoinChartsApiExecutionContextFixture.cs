using System;
using System.Linq;
using Bitcoin.Api.Context;
using Bitcoin.Api.Request;
using Bitcoin.Api.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitcoin.Tests.Context
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   (Unit Test Class) a bitcoin charts API execution context fixture. </summary>
    ///
    /// <remarks>   Maxim, 1/19/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [TestClass]
    public class BitcoinChartsApiExecutionContextFixture
    {

        /// <summary>   sample stub request. </summary>
        private readonly BitcoinChartsApiRequest _request = new BitcoinChartsApiRequest
        {
            TimeSpan = new System.TimeSpan(1, 0, 0, 0),
            Start = System.DateTime.Now.AddDays(-2)
        };

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// (Unit Test Method) can get request values with proper date times from valid request.
        /// </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanGetRequestValuesWithProperDateTimesFromValidRequest()
        {
            BitcoinChartsApiResponse response;
            var result = BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>.TryExecute(_request.CreateRequest(),
                out response);

            Assert.IsTrue(result);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.ConvertedValues);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// (Unit Test Method) can execute from static bitcoin API context with REST request.
        /// </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanExecuteFromStaticBitcoinApiContextWithRestRequest()
        {
            BitcoinChartsApiResponse response;
            var result = BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>.TryExecute(_request.CreateRequest(),
                out response);

            Assert.IsTrue(result);
            Assert.IsNotNull(response);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// (Unit Test Method) can execute from static bitcoin API context with bitcoin request.
        /// </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanExecuteFromStaticBitcoinApiContextWithBitcoinRequest()
        {
            BitcoinChartsApiResponse response;
            var result = BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>.TryExecute(_request, out response);

            Assert.IsTrue(result);
            Assert.IsNotNull(response);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// (Unit Test Method) can execute request from bitcoin API request with hours.
        /// </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanExecuteRequestFromBitcoinApiRequestWithHours()
        {
            var context = new BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>();

            var result = context.Execute(_request);
            Assert.IsNotNull(result);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) default constructor produces valid URI. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void DefaultConstructorProducesValidUri()
        {
            var request = new BitcoinChartsApiExecutionContext<object>();
            Assert.AreEqual(request.Route, new Uri("https://api.blockchain.info/charts"));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can set new route produces valid URI. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanSetNewRouteProducesValidUri()
        {
            var uri = new Uri("https://api.blockchain.info/charts/someValue");
            var request = new BitcoinChartsApiExecutionContext<object>(uri);
            Assert.AreEqual(request.Route, uri);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can execute request from bitcoin API request. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanExecuteRequestFromBitcoinApiRequest()
        {
            var request = new BitcoinChartsApiRequest();
            var context = new BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>();

            var result = context.Execute(request);
            Assert.IsNotNull(result);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can execute request from i REST request. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanExecuteRequestFromIRestRequest()
        {
            var request = new BitcoinChartsApiRequest();
            var context = new BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>();

            var result = context.Execute(request.CreateRequest());
            Assert.IsNotNull(result);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can produce valid type on mapped response. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanProduceValidTypeOnMappedResponse()
        {
            var request = new BitcoinChartsApiRequest();
            var context = new BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>();

            var result = context.Execute(request.CreateRequest());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BitcoinChartsApiResponse));
            Assert.IsNotNull(result.Name);
            Assert.IsNotNull(result.Period);
            Assert.IsNotNull(result.Status);
            Assert.IsNotNull(result.Unit);
            Assert.IsNotNull(result.Values);
            Assert.IsNotNull(result.Values.First().X);
            Assert.IsNotNull(result.Values.First().Y);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) throw error on invalid mapping. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ThrowErrorOnInvalidMapping()
        {
            var request = new BitcoinChartsApiRequest();
            var context = new BitcoinChartsApiExecutionContext<double>();

            var result = context.Execute(request.CreateRequest());
        }
    }
}