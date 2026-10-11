using StoreApi.Communication.Store.Response;

namespace StoreApi.Application.UseCases.Store.GetByName
{
    public interface IGetStoreByName
    {
        public Task<ResponseStoreJson> Execute(string name);
    }
}
