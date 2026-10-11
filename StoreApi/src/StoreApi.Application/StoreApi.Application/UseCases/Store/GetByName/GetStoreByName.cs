using AutoMapper;
using StoreApi.Communication.Store.Response;
using StoreApi.Domain.Repositories.Stores;
using StoreApi.Exception.ExceptionBase;

namespace StoreApi.Application.UseCases.Store.GetByName
{
    public class GetStoreByName : IGetStoreByName
    {
        private readonly IStoreReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetStoreByName(IStoreReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseStoreJson> Execute(string name)
        {
            Validate(name);
            var result = await _repository.GetByName(name);
            if (result is null)
            {
                throw new NotFoundException("Item nao encontrado");
            }
            return _mapper.Map<ResponseStoreJson>(result);
        }

        private void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var errorMessages = new List<string>() { "Nao pode ser vazio" };
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
