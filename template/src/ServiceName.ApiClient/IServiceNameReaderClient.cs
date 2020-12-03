using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace Swisschain.SwisschainProductName.ServiceName.ApiClient
{
    public interface IServiceNameReaderClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
        //DataReaderApi.DataReaderApiClient DataReaderApi { get; }
    }
}
