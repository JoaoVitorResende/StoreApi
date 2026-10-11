using AutoMapper;
using StoreApi.Communication.Item.Response;
using StoreApi.Domain.Repositories.Items;
using StoreApi.Exception.ExceptionBase;

namespace StoreApi.Application.UseCases.Itens.GetByID
{
    public class GetItemByID : IGetItemByID
    {
        private readonly IItemReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        public GetItemByID(IItemReadOnlyRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ResponseItemJson> Execute(string id)
        {
            Validate(id);
            var result = await _repository.GetById(id);
            if (result is null)
            {
                throw new NotFoundException("Item nao encontrado");
            }
            return _mapper.Map<ResponseItemJson>(result);
        }

        private void Validate(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                var errorMessages = new List<string>() { "Nao pode ser nulo" };
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
