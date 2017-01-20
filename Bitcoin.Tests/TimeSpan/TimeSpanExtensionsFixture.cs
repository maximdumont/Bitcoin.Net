using Bitcoin.Api.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitcoin.Tests.TimeSpan
{
    [TestClass]
    public class TimeSpanExtensionsFixture
    {
        [TestMethod]
        public void CanParseOneDayToValidString()
        {
            var ts = new System.TimeSpan(1, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "1days");
        }

        [TestMethod]
        public void CanParseTwoDaysToValidString()
        {
            var ts = new System.TimeSpan(2, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "2days");
        }

        [TestMethod]
        public void CanParseOneYearToValidString()
        {
            var ts = new System.TimeSpan(365, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "1years");
        }

        [TestMethod]
        public void CanParseTwoYearsToValidString()
        {
            var ts = new System.TimeSpan(2 * 365, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "2years");
        }

        [TestMethod]
        public void CanParseOneWeekToValidString()
        {
            var ts = new System.TimeSpan(7, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "1weeks");
        }

        [TestMethod]
        public void CanParseTwoWeeksToValidString()
        {
            var ts = new System.TimeSpan(14, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "2weeks");
        }

        [TestMethod]
        public void CanParseOneHourToValidString()
        {
            var ts = new System.TimeSpan(0, 1, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "1hours");
        }

        [TestMethod]
        public void CanParseTwoHoursToValidString()
        {
            var ts = new System.TimeSpan(0, 2, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "2hours");
        }
    }
}