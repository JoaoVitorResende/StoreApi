using StoreApi.Communication.Item.Response;

namespace StoreApi.Application.UseCases.Itens.GetByID
{
    public interface IGetItemByID
    {
        public Task<ResponseItens> Execute(long id);
    }
}
