﻿using System.Threading.Tasks;
using ServiceName.Common.Persistence.Entities;

namespace ServiceName.Common.Persistence.Repositories
{
    public interface IExampleRepository
    {
        Task UpsertAsync(ExampleEntity example);
        Task<ExampleEntity> GetAsync(string id);
        Task DeleteAsync(string id);
    }
}
