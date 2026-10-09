using StoreApi.Domain.Entities;

namespace StoreApi.Domain.Repositories.Stores
{
    public interface IStoreWriteOnlyRepository
    {
        Task Add(Store store);
    }
}
