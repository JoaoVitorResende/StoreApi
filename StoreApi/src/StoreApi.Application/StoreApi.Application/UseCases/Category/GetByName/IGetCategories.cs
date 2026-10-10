using StoreApi.Communication.Category.Response;

namespace StoreApi.Application.UseCases.Category.Get
{
    public interface IGetCategories
    {
        public Task<ReponseCategories> Execute(string name);
    }
}
