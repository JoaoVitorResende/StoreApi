using Microsoft.EntityFrameworkCore;
using StoreApi.Domain.Entities;
using StoreApi.Domain.Repositories.Stores;

namespace StoreApi.Infrastructure.DataAccess.Postgres.Repositories
{
    internal class StoreRepository : IStoreReadOnlyRepository, IStoreWriteOnlyRepository
    {
        private readonly StoreDbContext _dbContext;

        public StoreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Store store)
        {
            await _dbContext.Stores.AddAsync(store);
        }

        public async Task<Store?> GetById(long id)
        {
            return await _dbContext.Stores
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Store?> GetByName(string name)
        {
            return await _dbContext.Stores
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Title == name);
        }
    }
}
