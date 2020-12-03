using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceName.Common.Configuration;
using ServiceName.Common.Persistence.DbContexts;
using ServiceName.ManagerApi.GrpcServices;
using ServiceName.ManagerApi.Modules;
using Swisschain.Extensions.EfCore;
using Swisschain.Sdk.Server.Common;

namespace ServiceName.ManagerApi
{
    public sealed class Startup : SwisschainStartup<AppConfig>
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        protected override void ConfigureServicesExt(IServiceCollection services)
        {
            services.AddEfCoreDbValidation(c =>
            {
                c.UseDbContextFactory(s =>
                {
                    var options = s.GetRequiredService<DbContextOptionsBuilder<DatabaseContext>>();
                    return new DatabaseContext(options.Options);
                });
            });
        }

        protected override void RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            base.RegisterEndpoints(endpoints);

            endpoints.MapGrpcService<MonitoringService>();
            endpoints.MapGrpcService<ManagerApiService>();
        }

        protected override void ConfigureContainerExt(ContainerBuilder builder)
        {
            //builder.RegisterModule(new DbModule(Config.SwisschainProductNameServiceNameSettings.Db.ConnectionString));
            builder.RegisterModule(new ManagerApiModule());
            base.ConfigureContainerExt(builder);
        }
    }
}
