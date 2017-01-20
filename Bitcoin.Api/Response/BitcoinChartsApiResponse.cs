using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitcoin.Api.Response
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A bitcoin charts API response. </summary>
    ///
    /// <remarks>   Maxim, 1/19/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class BitcoinChartsApiResponse
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ///
        /// <param name="status">   The status. </param>
        /// <param name="name">     The name. </param>
        /// <param name="unit">     The unit. </param>
        /// <param name="period">   The period. </param>
        /// <param name="points">   The points. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BitcoinChartsApiResponse(string status, string name, string unit, string period,
            List<RawBitcoinPoint> points)
        {
            Status = status;
            Name = name;
            Unit = unit;
            Period = period;
            Values = points;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BitcoinChartsApiResponse()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets whether request succesful </summary>
        ///
        /// <value> The status. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Status { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the chart type used for request </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Name { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Currency Used For Request. Default is dollars </summary>
        ///
        /// <value> The unit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Unit { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the period of time for request. Default is day by day </summary>
        ///
        /// <value> The period. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Period { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the raw values returned by bitcoin API </summary>
        ///
        /// <value> The values. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<RawBitcoinPoint> Values { get; set; }


        /// <summary>   The converted values from Raw Values witrh converted datetimes for unit timestamp </summary>
        public List<ConvertedBitcoinPoint> ConvertedValues => Values.Select(m => new ConvertedBitcoinPoint(m)).ToList();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Maxim, 1/19/2017. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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