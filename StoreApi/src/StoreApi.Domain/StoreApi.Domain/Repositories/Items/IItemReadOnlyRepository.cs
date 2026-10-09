using StoreApi.Domain.Entities;

namespace StoreApi.Domain.Repositories.Items
{
    public interface IItemReadOnlyRepository
    {
        Task<Item?> GetById(string id);
    }
}
