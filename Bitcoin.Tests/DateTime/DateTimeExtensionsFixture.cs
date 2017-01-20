using Bitcoin.Api.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitcoin.Tests.DateTime
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   (Unit Test Class) a date time extensions fixture. </summary>
    ///
    /// <remarks>   Maxim, 1/19/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [TestClass]
    public class DateTimeExtensionsFixture
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (Unit Test Method) can get valid unix time stamp for long. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void CanGetValidUnixTimeStampForLong()
        {
            var l = 1442534400;
            var stamp = l.ToUnixTimeStamp();
            Assert.AreEqual(stamp.Year, 2015);
        }
    }
}