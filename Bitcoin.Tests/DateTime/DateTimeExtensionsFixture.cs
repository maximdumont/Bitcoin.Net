using Bitcoin.Api.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitcoin.Tests.DateTime
{
    [TestClass]
    public class DateTimeExtensionsFixture
    {
        [TestMethod]
        public void CanGetVaidUnixTimeStampForLong()
        {
            var l = 1442534400;
            var stamp = l.ToUnixTimeStamp();
            Assert.AreEqual(stamp.Year, 2015);
        }
    }
}