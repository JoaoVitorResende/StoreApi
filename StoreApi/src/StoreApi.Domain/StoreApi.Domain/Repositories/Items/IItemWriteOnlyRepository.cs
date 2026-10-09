
using StoreApi.Domain.Entities;

namespace StoreApi.Domain.Repositories.Items
{
    public interface IItemWriteOnlyRepository
    {
        Task Add(Item item);
        Task Update(Item item);
        Task Delete(string id);
    }
}
