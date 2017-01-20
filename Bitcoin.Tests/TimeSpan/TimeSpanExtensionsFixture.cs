using Bitcoin.Api.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitcoin.Tests.TimeSpan
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   (Unit Test Class) a time span extensions fixture. </summary>
    ///
    /// <remarks>   Maxim, 1/19/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [TestClass]
    public class TimeSpanExtensionsFixture
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can parse one day to valid string. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanParseOneDayToValidString()
        {
            var ts = new System.TimeSpan(1, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "1days");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can parse two days to valid string. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanParseTwoDaysToValidString()
        {
            var ts = new System.TimeSpan(2, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "2days");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can parse one year to valid string. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanParseOneYearToValidString()
        {
            var ts = new System.TimeSpan(365, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "1years");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can parse two years to valid string. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanParseTwoYearsToValidString()
        {
            var ts = new System.TimeSpan(2 * 365, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "2years");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can parse one week to valid string. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanParseOneWeekToValidString()
        {
            var ts = new System.TimeSpan(7, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "1weeks");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can parse two weeks to valid string. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanParseTwoWeeksToValidString()
        {
            var ts = new System.TimeSpan(14, 0, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "2weeks");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can parse one hour to valid string. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanParseOneHourToValidString()
        {
            var ts = new System.TimeSpan(0, 1, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "1hours");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can parse two hours to valid string. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanParseTwoHoursToValidString()
        {
            var ts = new System.TimeSpan(0, 2, 0, 0);
            var result = ts.ToTimeString();

            Assert.AreEqual(result, "2hours");
        }
    }
}