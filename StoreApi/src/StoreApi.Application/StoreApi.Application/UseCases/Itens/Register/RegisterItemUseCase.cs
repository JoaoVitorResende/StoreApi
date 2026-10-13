using AutoMapper;
using StoreApi.Communication.Item.Request;
using StoreApi.Communication.Item.Response;
using StoreApi.Domain.Entities;
using StoreApi.Domain.Repositories.Items;
using StoreApi.Exception.ExceptionBase;

namespace StoreApi.Application.UseCases.Itens.Register
{
    public class RegisterItemUseCase : IRegisterItemUseCase
    {
        private readonly IMapper _autoMapper;
        private readonly IItemWriteOnlyRepository _repository;
        public RegisterItemUseCase(IMapper autoMapper, IItemWriteOnlyRepository repository)
        {
            _autoMapper = autoMapper;
            _repository = repository;
        }
        public async Task<ResponseRegisterItemJson> Execute(RequestItemJson req)
        {
            Validation(req);
            var entity = _autoMapper.Map<Item>(req);
            await _repository.Add(entity);
            return _autoMapper.Map<ResponseRegisterItemJson>(entity);
        }

        private void Validation(RequestItemJson req)
        {
            var validator = new ItemValidator();
            var result = validator.Validate(req);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
