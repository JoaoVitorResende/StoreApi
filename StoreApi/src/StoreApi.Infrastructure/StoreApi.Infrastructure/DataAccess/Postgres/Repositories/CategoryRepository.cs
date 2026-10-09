using Microsoft.EntityFrameworkCore;
using StoreApi.Domain.Entities;
using StoreApi.Domain.Repositories.Categories;

namespace StoreApi.Infrastructure.DataAccess.Postgres.Repositories
{
    internal class CategoryRepository : ICategoryReadOnlyRepository, ICategoryWriteOnlyRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
        }

        public async Task<bool> ExistsById(long id)
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsByName(string name)
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Name == name);
        }
    }
}
