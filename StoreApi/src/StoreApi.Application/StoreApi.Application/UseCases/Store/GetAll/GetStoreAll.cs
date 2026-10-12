using AutoMapper;
using StoreApi.Communication.Store.Response;
using StoreApi.Domain.Repositories.Stores;

namespace StoreApi.Application.UseCases.Store.GetAll
{
    public class GetStoreAll : IGetStoreAll
    {
        private readonly IStoreReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        public GetStoreAll(IStoreReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseStores> Execute()
        {
            var result = await _repository.GetAll();
            return new ResponseStores 
            {
                Stores = _mapper.Map<List<ResponseStoreJson>>(result)
            };
        }
    }
}
