using StoreApi.Communication.Store.Response;

namespace StoreApi.Application.UseCases.Store.GetAll
{
    public interface IGetStoreAll
    {
        Task<ResponseStores> Execute();
    }
}
