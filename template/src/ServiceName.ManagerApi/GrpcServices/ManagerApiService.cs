using System.Threading.Tasks;
using Grpc.Core;
using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace ServiceName.ManagerApi.GrpcServices
{
    public class ManagerApiService : Swisschain.SwisschainProductName.ServiceName.ApiContract.ManagerApi.ManagerApiBase
    {
        public override async Task<SetExampleResponse> SetSomething(SetExampleRequest request, ServerCallContext context)
        {
            return await base.SetSomething(request, context);
        }
    }
}
