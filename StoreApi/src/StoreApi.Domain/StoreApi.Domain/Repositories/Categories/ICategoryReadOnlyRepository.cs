using StoreApi.Domain.Entities;

namespace StoreApi.Domain.Repositories.Categories
{
    public interface ICategoryReadOnlyRepository
    {
        Task<Category?> GetById(long id);
        Task<Category?> GetByName(string normalizedName);
        Task<List<Category>> GetAll();
    }
}
