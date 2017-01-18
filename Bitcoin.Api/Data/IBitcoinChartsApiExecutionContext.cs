using RestSharp;

namespace Bitcoin.Api.Data
{
    public interface IBitcoinChartsApiExecutionContext<out T> where T : new()
    {
        T Execute(IRestRequest request);
        T Execute(IBitcoinApiRequest request);
    }
}