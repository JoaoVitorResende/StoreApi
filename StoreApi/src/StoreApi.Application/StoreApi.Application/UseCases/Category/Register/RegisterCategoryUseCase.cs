using AutoMapper;
using StoreApi.Communication.Category.Request;
using StoreApi.Communication.Category.Response;
using StoreApi.Domain.Repositories;
using StoreApi.Domain.Repositories.Categories;
namespace StoreApi.Application.UseCases.Category.Register
{
    public class RegisterCategoryUseCase : IRegisterCategoryUseCase
    {
        private readonly IMapper _autoMapper;
        private readonly ICategoryWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterCategoryUseCase(IMapper autoMapper, ICategoryWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _autoMapper = autoMapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisterCategoryJson> Execute(RequestCategoryJson req)
        {
            Validate(req);
            var entity = _autoMapper.Map<Domain.Entities.Category>(req);

            await _repository.Add(entity);
            await _unitOfWork.Commit();
            return _autoMapper.Map<ResponseRegisterCategoryJson>(entity);
        }

        private void Validate(RequestCategoryJson req)
        {
            var validator = new CategoryValidator();
            var result = validator.Validate(req);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
