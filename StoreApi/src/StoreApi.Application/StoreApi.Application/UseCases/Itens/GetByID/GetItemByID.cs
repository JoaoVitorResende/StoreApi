using AutoMapper;
using StoreApi.Communication.Item.Response;
using StoreApi.Domain.Repositories.Categories;
using StoreApi.Exception.ExceptionBase;

namespace StoreApi.Application.UseCases.Itens.GetByID
{
    public class GetItemByID : IGetItemByID
    {
        private readonly ICategoryReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        public GetItemByID(ICategoryReadOnlyRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ResponseItens> Execute(long id)
        {
            Validate(id);
            var result = await _repository.ExistsById(id);
            if (result is null)
            {
                throw new NotFoundException("Item nao encontrado");
            }
            return _mapper.Map<ResponseItens>(result);
        }

        private void Validate(long id)
        {
            if (id < 0)
            {
                var errorMessages = new List<string>() { "Nao pode ser menor que zero" };
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
