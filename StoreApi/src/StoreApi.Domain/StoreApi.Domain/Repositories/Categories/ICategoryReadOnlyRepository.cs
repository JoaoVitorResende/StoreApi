namespace StoreApi.Domain.Repositories.Categories
{
    public interface ICategoryReadOnlyRepository
    {
        Task<bool> ExistsById(long id);
        Task<bool> ExistsByName(string normalizedName);
    }
}
