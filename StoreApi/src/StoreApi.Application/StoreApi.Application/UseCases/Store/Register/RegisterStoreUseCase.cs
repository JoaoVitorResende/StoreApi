using AutoMapper;
using StoreApi.Communication.Store.Request;
using StoreApi.Communication.Store.Response;

namespace StoreApi.Application.UseCases.Store.Register
{
    public class RegisterStoreUseCase : IRegisterStoreUseCase
    {
        private readonly IMapper _autoMapper;
        public RegisterStoreUseCase(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }
        public async Task<ResponseRegisterStoreJson> Execute(RequestStoreJson req)
        {
            var entity = _autoMapper.Map<Domain.Entities.Store>(req);


            return _autoMapper.Map<ResponseRegisterStoreJson>(entity);
        }
    }
}
