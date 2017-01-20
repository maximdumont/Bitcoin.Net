using System;
using Bitcoin.Api.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Bitcoin.Tests.Request
{
    [TestClass]
    public class BitcoinChartsApiRequestFixture
    {
        [TestMethod]
        public void BitcoinChartsApiRequestAssignableFromInterfaceSuccess()
        {
            var request = new BitcoinChartsApiRequest();
            Assert.IsInstanceOfType(request, typeof(IBitcoinApiRequest));
        }

        [TestMethod]
        public void PopulatedRequestsContainsCorrectDefaultValues()
        {
            var request = new BitcoinChartsApiRequest();

            Assert.AreEqual(request.ChartType, "market-price");
            Assert.AreEqual(request.TimeSpan.Days, 180);
            Assert.AreEqual(request.RollingAverage.Days, 180);
        }

        [TestMethod]
        public void PopulateRequestsWithNewValuesIsCorrect()
        {
            var request = new BitcoinChartsApiRequest
            {
                ChartType = "My New Chart",
                RollingAverage = new System.TimeSpan(170, 0, 0, 0),
                Start = System.DateTime.MaxValue,
                TimeSpan = new System.TimeSpan(170, 0, 0, 0)
            };

            Assert.AreEqual(request.ChartType, "My New Chart");
            Assert.AreEqual(request.TimeSpan.Days, 170);
            Assert.AreEqual(request.RollingAverage.Days, 170);
            Assert.AreEqual(request.Start, System.DateTime.MaxValue);
        }

        [TestMethod]
        public void CreatingRequestProducesValidRequest()
        {
            var request = new BitcoinChartsApiRequest
            {
                TimeSpan = new System.TimeSpan(1, 0, 0, 0)
            };
            var restRequest = request.CreateRequest();

            Assert.IsInstanceOfType(restRequest, typeof(IRestRequest));
            Assert.AreEqual(restRequest.Resource, request.ChartType);
            Assert.AreEqual(restRequest.Parameters.Count, 5);
        }
    }
}