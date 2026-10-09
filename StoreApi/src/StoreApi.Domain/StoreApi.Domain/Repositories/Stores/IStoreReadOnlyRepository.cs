namespace StoreApi.Domain.Repositories.Stores
{
    public interface IStoreReadOnlyRepository
    {
        Task<bool> ExistsById(long id);
        Task<bool> ExistsByName(string normalizedName);
    }
}
