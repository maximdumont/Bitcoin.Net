using System;
using System.Linq;
using Bitcoin.Api.Context;
using Bitcoin.Api.Request;
using Bitcoin.Api.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitcoin.Tests.Context
{
    [TestClass]
    public class BitcoinChartsApiExecutionContextFixture
    {
        private readonly BitcoinChartsApiRequest _request = new BitcoinChartsApiRequest
        {
            TimeSpan = new System.TimeSpan(1, 0, 0, 0),
            Start = System.DateTime.Now.AddDays(-2)
        };

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

        [TestMethod]
        public void CanExecuteFromStaticBitcoinApiContextWithRestRequest()
        {
            BitcoinChartsApiResponse response;
            var result = BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>.TryExecute(_request.CreateRequest(),
                out response);

            Assert.IsTrue(result);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void CanExecuteFromStaticBitcoinApiContextWithBitcoinRequest()
        {
            BitcoinChartsApiResponse response;
            var result = BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>.TryExecute(_request, out response);

            Assert.IsTrue(result);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void CanExecuteRequestFromBitcoinApiRequestWithHours()
        {
            var context = new BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>();

            var result = context.Execute(_request);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DefaultConstructorProducesValidUri()
        {
            var request = new BitcoinChartsApiExecutionContext<object>();
            Assert.AreEqual(request.Route, new Uri("https://api.blockchain.info/charts"));
        }

        [TestMethod]
        public void CanSetNewRouteProducesValidUri()
        {
            var uri = new Uri("https://api.blockchain.info/charts/someValue");
            var request = new BitcoinChartsApiExecutionContext<object>(uri);
            Assert.AreEqual(request.Route, uri);
        }

        [TestMethod]
        public void CanExecuteRequestFromBitcoinApiRequest()
        {
            var request = new BitcoinChartsApiRequest();
            var context = new BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>();

            var result = context.Execute(request);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanExecuteRequestFromIRestRequest()
        {
            var request = new BitcoinChartsApiRequest();
            var context = new BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>();

            var result = context.Execute(request.CreateRequest());
            Assert.IsNotNull(result);
        }

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