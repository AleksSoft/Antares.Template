using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace Swisschain.SwisschainProductName.ServiceName.ApiClient
{
    public interface IServiceNameReaderClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
        //TODO: use DataReaderApiClient when it will be generated
        //DataReaderApi.DataReaderApiClient DataReaderApi { get; }
    }
}
