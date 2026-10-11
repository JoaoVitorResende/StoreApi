using StoreApi.Communication.Store.Request;
using StoreApi.Communication.Store.Response;

namespace StoreApi.Application.UseCases.Store.Register
{
    public interface IRegisterStoreUseCase
    {
        public Task<ResponseStoreJson> Execute(RequestStoreJson req);
    }
}
