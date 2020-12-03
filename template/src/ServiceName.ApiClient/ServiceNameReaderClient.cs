using Swisschain.SwisschainProductName.ServiceName.ApiClient.Common;
using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace Swisschain.SwisschainProductName.ServiceName.ApiClient
{
    public class ServiceNameReaderClient : BaseGrpcClient, IServiceNameReaderClient
    {
        public ServiceNameReaderClient(string serverGrpcUrl) : base(serverGrpcUrl)
        {
            Monitoring = new Monitoring.MonitoringClient(Channel);
            DataReaderApi = new DataReaderApi.DataReaderApiClient(Channel);
        }

        public Monitoring.MonitoringClient Monitoring { get; }
        public DataReaderApi.DataReaderApiClient DataReaderApi { get; set; }
    }
}
