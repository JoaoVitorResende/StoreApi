using AutoMapper;
using StoreApi.Communication.Category.Request;
using StoreApi.Communication.Category.Response;
using StoreApi.Domain.Repositories;
using StoreApi.Domain.Repositories.Categories;
using StoreApi.Exception.ExceptionBase;
namespace StoreApi.Application.UseCases.Category.Register
{
    public class RegisterCategoryUseCase : IRegisterCategoryUseCase
    {
        private readonly IMapper _autoMapper;
        private readonly ICategoryWriteOnlyRepository _writeRepository;
        private readonly ICategoryReadOnlyRepository _readRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterCategoryUseCase(IMapper autoMapper, ICategoryWriteOnlyRepository repository, IUnitOfWork unitOfWork, ICategoryReadOnlyRepository readRepository)
        {
            _autoMapper = autoMapper;
            _writeRepository = repository;
            _unitOfWork = unitOfWork;
            _readRepository = readRepository;
        }

        public async Task<ResponseRegisterCategoryJson> Execute(RequestCategoryJson req)
        {
            Validate(req);
            var name = Domain.Entities.Category.Normalize(req.Name);

            var existing = await _readRepository.GetByName(name);
            if (existing is not null)
                throw new ErrorOnValidationException(["Ja existe uma categoria com esse nome"]);

            var entity = _autoMapper.Map<Domain.Entities.Category>(req);
            entity.Name = name;

            await _writeRepository.Add(entity);
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
