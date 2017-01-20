using System;
using RestSharp;

namespace Bitcoin.Api.Request
{
    public interface IBitcoinChartsApiRequest
    {
        string ChartType { get; set; }
        IRestRequest CreateRequest();
    }
}