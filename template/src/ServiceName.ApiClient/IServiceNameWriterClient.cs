using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace Swisschain.SwisschainProductName.ServiceName.ApiClient
{
    public interface IServiceNameWriterClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
        //TODO: use ManagerApiClient when it will be generated
        //ManagerApi.ManagerApiClient ManagerApi { get; }
    }
}
