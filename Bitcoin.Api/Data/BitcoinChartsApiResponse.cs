using System.Collections.Generic;
using System.Text;

namespace Bitcoin.Api.Data
{
    public class BitcoinChartsApiResponse
    {
        public BitcoinChartsApiResponse(string status, string name, string unit, string period,
            List<BitcoinPoint> points)
        {
            Status = status;
            Name = name;
            Unit = unit;
            Period = period;
            Values = points;
        }

        public BitcoinChartsApiResponse()
        {
        }

        public string Status { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Period { get; set; }
        public List<BitcoinPoint> Values { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Status - {Status}");
            builder.AppendLine($"Name - {Name}");
            builder.AppendLine($"Unit - {Unit}");
            builder.AppendLine($"Period - {Period}");

            return builder.ToString();
        }
    }
}