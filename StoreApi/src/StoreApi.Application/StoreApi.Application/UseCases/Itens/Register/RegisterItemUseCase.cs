using AutoMapper;
using StoreApi.Communication.Item.Request;
using StoreApi.Communication.Item.Response;
using StoreApi.Domain.Entities;

namespace StoreApi.Application.UseCases.Itens.Register
{
    public class RegisterItemUseCase : IRegisterItemUseCase
    {
        private readonly IMapper _autoMapper;
        public RegisterItemUseCase(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }
        public async Task<ResponseRegisterItemJson> Execute(RequestItemJson request)
        {
            var entity = _autoMapper.Map<Item>(request);


            return _autoMapper.Map<ResponseRegisterItemJson>(entity);
        }
    }
}
