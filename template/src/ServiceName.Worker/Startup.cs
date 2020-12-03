using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceName.Common.Configuration;
using ServiceName.Common.HostedServices;
using ServiceName.Common.Persistence;
using ServiceName.Common.Persistence.DbContexts;
using ServiceName.Worker.Modules;
using Swisschain.Extensions.EfCore;
using Swisschain.Sdk.Server.Common;

namespace ServiceName.Worker
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
            services.AddEfCoreDbMigration(c =>
            {
                c.UseDbContextFactory(s =>
                {
                    var options = s.GetRequiredService<DbContextOptionsBuilder<DatabaseContext>>();
                    return new DatabaseContext(options.Options);
                });
            });

            services.AddHttpClient();
            services.AddHostedService<ExampleHost>();
        }

        protected override void ConfigureContainerExt(ContainerBuilder builder)
        {
            //builder.RegisterModule(new DbModule(Config.SwisschainProductNameServiceNameSettings.Db.ConnectionString));
            builder.RegisterModule(new WorkerModule());

            base.ConfigureContainerExt(builder);
        }

        protected override void RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            base.RegisterEndpoints(endpoints);

        }
    }
}
