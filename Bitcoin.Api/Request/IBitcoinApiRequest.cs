using System.Collections.Generic;
using RestSharp;

namespace Bitcoin.Api.Request
{
    public interface IBitcoinApiRequest
    {
        string ChartType { get; set; }
        IRestRequest CreateRequest();
    }
}