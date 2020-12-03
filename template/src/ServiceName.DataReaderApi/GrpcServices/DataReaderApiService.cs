using System.Threading.Tasks;
using Grpc.Core;
using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace ServiceName.DataReaderApi.GrpcServices
{
    public class DataReaderApiService : Swisschain.SwisschainProductName.ServiceName.ApiContract.DataReaderApi.DataReaderApiBase
    {
        public override async Task<GetExampleResponse> GetSomething(GetExampleRequest request, ServerCallContext context)
        {
            return await base.GetSomething(request, context);
        }
    }
}
