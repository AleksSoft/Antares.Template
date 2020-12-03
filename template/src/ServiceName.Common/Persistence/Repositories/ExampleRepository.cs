using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ServiceName.Common.Persistence.DbContexts;
using ServiceName.Common.Persistence.Entities;

namespace ServiceName.Common.Persistence.Repositories
{
    internal sealed class ExampleRepository : IExampleRepository
    {
        private readonly DbContextOptionsBuilder<DatabaseContext> _dbContextOptionsBuilder;

        public ExampleRepository(DbContextOptionsBuilder<DatabaseContext> dbContextOptionsBuilder)
        {
            _dbContextOptionsBuilder = dbContextOptionsBuilder;
        }

        public async Task UpsertAsync(ExampleEntity example)
        {
            await using var context = new DatabaseContext(_dbContextOptionsBuilder.Options);

            context.Examples.Add(example);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                context.Examples.Update(example);

                await context.SaveChangesAsync();
            }
        }

        public async Task<ExampleEntity> GetOrDefaultAsync(string id)
        {
            await using var context = new DatabaseContext(_dbContextOptionsBuilder.Options);

            return await context
                .Examples
                .FindAsync(id);
        }

        public async Task DeleteAsync(string id)
        {
            await using var context = new DatabaseContext(_dbContextOptionsBuilder.Options);

            var example = new ExampleEntity { Id = id };
            context.Examples.Attach(example);
            context.Examples.Remove(example);

            await context.SaveChangesAsync();
        }
    }
}
