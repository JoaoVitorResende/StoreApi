using AutoMapper;
using StoreApi.Communication.Category.Response;
namespace StoreApi.Application.UseCases.Category.Register
{
    public class RegisterCategoryUseCase : IRegisterCategoryUseCase
    {
        private readonly IMapper _autoMapper;
        public RegisterCategoryUseCase(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        public async Task<ResponseRegisterCategoryJson> Execute(RegisterCategoryUseCase req)
        {
            var entity = _autoMapper.Map<Domain.Entities.Category>(req);


            return _autoMapper.Map<ResponseRegisterCategoryJson>(entity);
        }
    }
}
