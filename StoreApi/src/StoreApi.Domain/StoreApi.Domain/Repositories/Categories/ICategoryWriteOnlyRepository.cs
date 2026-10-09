using StoreApi.Domain.Entities;

namespace StoreApi.Domain.Repositories.Categories
{
    public interface ICategoryWriteOnlyRepository
    {
        Task Add(Category category);
    }
}
