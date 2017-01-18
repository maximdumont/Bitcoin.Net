using System;
using System.Linq;
using Bitcoin.Api.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project_S.Tests.Client
{
    [TestClass]
    public class BitcoinChartsApiExecutionContextFixture
    {
        [TestMethod]
        public void CanExecuteRequestFromBitcoinApiRequestWithHours()
        {
            var request = new BitcoinChartsApiRequest
            {
                TimeSpan = new TimeSpan(1, 0, 0, 0),
                Start = DateTime.Now.AddDays(-2)
            };
            var context = new BitcoinChartsApiExecutionContext<BitcoinChartsApiResponse>();

            var result = context.Execute(request);
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