using Microsoft.EntityFrameworkCore;
using ServiceName.Common.Persistence.Entities;

namespace ServiceName.Common.Persistence.DbContexts
{
    public class DatabaseContext : DbContext
    {
        public static string SchemaName { get; } = "api";
        public static string MigrationHistoryTable { get; } = "__EFMigrationsHistory";

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<ExampleEntity> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaName);

            modelBuilder.Entity<ExampleEntity>()
                .ToTable("example")
                .HasKey(x => x.Id);

            modelBuilder.Entity<ExampleEntity>()
                .HasIndex(x => x.Id)
                .HasName("IX_ExampleEntity_Index");

            base.OnModelCreating(modelBuilder);
        }
    }
}
