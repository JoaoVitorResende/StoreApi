using AutoMapper;
using StoreApi.Communication.Category.Response;
using StoreApi.Domain.Repositories.Categories;

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
        public async Task<ReponseCategories> Execute()
        {
            var result = await _repository.GetAll();

            return new ReponseCategories
            {
                categories = _mapper.Map<List<ResponseRegisterCategoryJson>>(result)
            };
        }
    }
}
