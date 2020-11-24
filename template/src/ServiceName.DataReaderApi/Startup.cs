using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceName.Common.Configuration;
using ServiceName.Common.Persistence;
using ServiceName.DataReaderApi.GrpcServices;
using ServiceName.DataReaderApi.Modules;
using Swisschain.Sdk.Server.Common;

namespace ServiceName.DataReaderApi
{
    public sealed class Startup : SwisschainStartup<AppConfig>
    {
        public AppConfig Config { get; }

        public Startup(IConfiguration configuration)
            : base(configuration)
        {
            Config = configuration.Get<AppConfig>();
        }

        protected override void ConfigureServicesExt(IServiceCollection services)
        {
            base.ConfigureServicesExt(services);
        }

        protected override void RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            base.RegisterEndpoints(endpoints);

            endpoints.MapGrpcService<MonitoringService>();
        }

        protected override void ConfigureContainerExt(ContainerBuilder builder)
        {
            //builder.RegisterModule(new DbModule(Config.SwisschainProductNameServiceNameSettings.Db.ConnectionString));
            builder.RegisterModule(new ManagerApiModule());
            base.ConfigureContainerExt(builder);
        }
    }
}
