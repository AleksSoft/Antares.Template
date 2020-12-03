using Swisschain.SwisschainProductName.ServiceName.ApiClient.Common;
using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace Swisschain.SwisschainProductName.ServiceName.ApiClient
{
    public class ServiceNameWriterClient : BaseGrpcClient, IServiceNameWriterClient
    {
        public ServiceNameWriterClient(string serverGrpcUrl) : base(serverGrpcUrl)
        {
            Monitoring = new Monitoring.MonitoringClient(Channel);
            //ManagerApi = new ManagerApi.ManagerApiClient(Channel);
        }

        public Monitoring.MonitoringClient Monitoring { get; }
        //public ManagerApi.ManagerApiClient ManagerApi { get; set; }
    }
}
