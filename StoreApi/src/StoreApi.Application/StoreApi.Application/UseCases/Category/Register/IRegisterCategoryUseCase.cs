using StoreApi.Communication.Category.Request;
using StoreApi.Communication.Category.Response;

namespace StoreApi.Application.UseCases.Category.Register
{
    public interface IRegisterCategoryUseCase
    {
        public Task<ResponseRegisterCategoryJson> Execute(RequestCategoryJson req);
    }
}
