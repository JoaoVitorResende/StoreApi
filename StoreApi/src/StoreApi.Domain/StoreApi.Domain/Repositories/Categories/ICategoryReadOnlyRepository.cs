using StoreApi.Domain.Entities;

namespace StoreApi.Domain.Repositories.Categories
{
    public interface ICategoryReadOnlyRepository
    {
        Task<Item> ExistsById(long id);
        Task<Item> ExistsByName(string normalizedName);
    }
}
