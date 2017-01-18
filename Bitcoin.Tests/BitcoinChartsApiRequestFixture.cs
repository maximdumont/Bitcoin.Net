using System;
using Bitcoin.Api.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Bitcoin.Tests
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
            Assert.AreEqual(request.DateTimeQueryStringFormat, "yyyy-MM-dd");
            Assert.AreEqual(request.Start.ToString(request.DateTimeQueryStringFormat),
                DateTime.Now.AddYears(-1).ToString(request.DateTimeQueryStringFormat));
            Assert.AreEqual(request.Format, "json");
            Assert.AreEqual(request.LimitTo1500, true);
        }

        [TestMethod]
        public void PopulateRequestsWithNewValuesIsCorrect()
        {
            var request = new BitcoinChartsApiRequest
            {
                ChartType = "My New Chart",
                DateTimeQueryStringFormat = "yyyy-dd-mm",
                Format = "csv",
                LimitTo1500 = false,
                RollingAverage = new TimeSpan(170, 0, 0, 0),
                Start = DateTime.MaxValue,
                TimeSpan = new TimeSpan(170, 0, 0, 0)
            };

            Assert.AreEqual(request.ChartType, "My New Chart");
            Assert.AreEqual(request.TimeSpan.Days, 170);
            Assert.AreEqual(request.RollingAverage.Days, 170);
            Assert.AreEqual(request.DateTimeQueryStringFormat, "yyyy-dd-mm");
            Assert.AreEqual(request.Start, DateTime.MaxValue);
            Assert.AreEqual(request.Format, "csv");
            Assert.AreEqual(request.LimitTo1500, false);
        }

        [TestMethod]
        public void CreatingRequestProducesValidRequest()
        {
            var request = new BitcoinChartsApiRequest();
            var restRequest = request.CreateRequest();

            Assert.IsInstanceOfType(restRequest, typeof(IRestRequest));
            Assert.AreEqual(restRequest.Resource, request.ChartType);
            Assert.AreEqual(restRequest.Parameters.Count, 5);
        }
    }
}