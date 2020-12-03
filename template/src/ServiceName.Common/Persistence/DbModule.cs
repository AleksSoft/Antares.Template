using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceName.Common.Persistence.DbContexts;

namespace ServiceName.Common.Persistence
{
    public class DbModule : Module
    {
        private readonly string _connectionString;

        public DbModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                optionsBuilder
                    .UseLoggerFactory(ctx.Resolve<ILoggerFactory>())
                    .UseNpgsql(_connectionString,
                        x => x.MigrationsHistoryTable(
                            DatabaseContext.MigrationHistoryTable,
                            DatabaseContext.SchemaName));

                return optionsBuilder;
            });
        }
    }
}
