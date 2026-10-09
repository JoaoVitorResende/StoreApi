using AutoMapper;
using StoreApi.Communication.Store.Request;
using StoreApi.Communication.Store.Response;
using StoreApi.Domain.Repositories;
using StoreApi.Domain.Repositories.Stores;

namespace StoreApi.Application.UseCases.Store.Register
{
    public class RegisterStoreUseCase : IRegisterStoreUseCase
    {
        private readonly IMapper _autoMapper;
        private readonly IStoreWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterStoreUseCase(IMapper autoMapper, IStoreWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _autoMapper = autoMapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseRegisterStoreJson> Execute(RequestStoreJson req)
        {
            Validation(req);
            var entity = _autoMapper.Map<Domain.Entities.Store>(req);
            
            await _repository.Add(entity);
            await _unitOfWork.Commit();
            return _autoMapper.Map<ResponseRegisterStoreJson>(entity);
        }
        private void Validation(RequestStoreJson req)
        {
            var validator = new StoreValidator();
            var result = validator.Validate(req);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
