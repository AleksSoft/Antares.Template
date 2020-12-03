using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace Swisschain.SwisschainProductName.ServiceName.ApiClient
{
    public interface IServiceNameWriterClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
        ManagerApi.ManagerApiClient ManagerApi { get; }
    }
}
