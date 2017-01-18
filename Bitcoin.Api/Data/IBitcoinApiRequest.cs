using System.Collections.Generic;
using RestSharp;

namespace Bitcoin.Api.Data
{
    public interface IBitcoinApiRequest
    {
        string ChartType { get; set; }
        Dictionary<string, object> RequestValues { get; }
        IRestRequest CreateRequest();
    }
}