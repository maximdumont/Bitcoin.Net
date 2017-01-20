using Bitcoin.Api.Request;
using RestSharp;

namespace Bitcoin.Api.Context
{
    public interface IBitcoinChartsApiExecutionContext<out T> where T : new()
    {
        T Execute(IRestRequest request);
        T Execute(IBitcoinApiRequest request);
    }
}