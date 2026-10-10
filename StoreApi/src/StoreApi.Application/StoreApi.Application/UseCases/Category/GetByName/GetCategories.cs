using AutoMapper;
using StoreApi.Communication.Category.Response;
using StoreApi.Domain.Repositories.Categories;
using StoreApi.Exception.ExceptionBase;

namespace StoreApi.Application.UseCases.Category.Get
{
    public class GetCategories : IGetCategories
    {
        private readonly ICategoryReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        public GetCategories(ICategoryReadOnlyRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ReponseCategories> Execute(string name)
        {
            Validate(name);
            var result = await _repository.ExistsByName(name);
            return new ReponseCategories
            {
                categories = _mapper.Map<List<string>>(result)
            };
        }
        private void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var errorMessages = new List<string>() { "Nao pode ser nulo" };
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
