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
        public async Task<ResponseItens> Execute(int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 50) pageSize = 50;

            var result = await _repository.GetAll(page, pageSize);

            return new ResponseItens
            {
                Itens = _mapper.Map<List<ResponseItemJson>>(result.Items),
                Page = page,
                PageSize = pageSize,
                TotalItens = result.Total,
                TotalPages = (int)Math.Ceiling(result.Total / (double)pageSize)
            };
        }
    }
}
