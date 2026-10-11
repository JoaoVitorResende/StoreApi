using StoreApi.Communication.Item.Response;

namespace StoreApi.Application.UseCases.Itens.GetAll
{
    public interface IGetAllItens
    {
        Task<ResponseItens> Execute();
    }
}
