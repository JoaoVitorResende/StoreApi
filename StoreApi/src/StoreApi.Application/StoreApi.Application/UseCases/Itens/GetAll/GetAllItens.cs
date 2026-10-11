using AutoMapper;
using StoreApi.Communication.Item.Response;
using StoreApi.Domain.Repositories.Items;

namespace StoreApi.Application.UseCases.Itens.GetAll
{
    public class GetAllItens : IGetAllItens
    {
        private readonly IItemReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        public GetAllItens(IItemReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseItens> Execute()
        {
            var result = await _repository.GetAll();

            return new ResponseItens
            {
                Itens = _mapper.Map<List<ResponseItemJson>>(result)
            };
        }
    }
}
