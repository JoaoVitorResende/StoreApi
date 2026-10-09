namespace StoreApi.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
