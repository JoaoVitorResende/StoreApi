using StoreApi.Communication.Category.Response;

namespace StoreApi.Application.UseCases.Category.Register
{
    public interface IRegisterCategoryUseCase
    {
        public Task<ResponseRegisterCategoryJson> Execute(RegisterCategoryUseCase req);
    }
}
