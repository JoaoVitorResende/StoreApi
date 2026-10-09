// Infrastructure/DataAccess/Postgres/UnitOfWork.cs
using StoreApi.Domain.Repositories;

namespace StoreApi.Infrastructure.DataAccess.Postgres.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;

        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}