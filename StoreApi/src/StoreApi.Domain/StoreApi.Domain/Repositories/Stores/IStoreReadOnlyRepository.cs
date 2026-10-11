using StoreApi.Domain.Entities;

namespace StoreApi.Domain.Repositories.Stores
{
    public interface IStoreReadOnlyRepository
    {
        Task<Store?> GetById(long id);
        Task<Store?> GetByName(string normalizedName);
    }
}
