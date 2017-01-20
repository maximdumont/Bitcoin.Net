using System;
using Bitcoin.Api.Extensions;

namespace Bitcoin.Api.Response
{
    public class ConvertedBitcoinPoint
    {
        public ConvertedBitcoinPoint(RawBitcoinPoint point)
        {
            CaptureDate = point.X.ToUnixTimeStamp();
            Value = point.Y;
        }

        public DateTime CaptureDate { get; }
        public double Value { get; }
    }
}