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

        public async Task<Category?> GetById(long id)
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetByName(string name)
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == name);
        }
        public async Task<List<Category>> GetAll()
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}
