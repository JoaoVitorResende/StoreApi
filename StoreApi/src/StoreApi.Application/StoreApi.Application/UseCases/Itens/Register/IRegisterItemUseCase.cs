using StoreApi.Communication.Item.Request;
using StoreApi.Communication.Item.Response;

namespace StoreApi.Application.UseCases.Itens.Register
{
    public interface IRegisterItemUseCase
    {
        public Task<ResponseRegisterItemJson> Execute(RequestItemJson request);
    }
}
