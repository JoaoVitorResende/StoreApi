using Bogus;
using StoreApi.Communication.Category.Request;
using StoreApi.Communication.Item.Request;
using StoreApi.Communication.Store.Request;

namespace StoreApi.Application.Tests.Utils
{
    public static class RequestBuilders
    {
        public static RequestCategoryJson Category() =>
            new Faker<RequestCategoryJson>()
                .RuleFor(r => r.Name, f => f.Commerce.Categories(1)[0])
                .Generate();

        public static RequestStoreJson Store() =>
            new Faker<RequestStoreJson>()
                .RuleFor(r => r.Title, f => f.Company.CompanyName())
                .RuleFor(r => r.Address, f => f.Address.FullAddress())
                .Generate();

        public static RequestItemJson Item() =>
            new Faker<RequestItemJson>()
                .RuleFor(r => r.Title, f => f.Commerce.ProductName())
                .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
                .RuleFor(r => r.Price, f => f.Random.Decimal(1, 1000))
                .RuleFor(r => r.Quantity, f => f.Random.Int(1, 500))
                .RuleFor(r => r.CategoryId, f => f.Random.Int(1, 50))
                .RuleFor(r => r.StoreId, f => f.Random.Int(1, 50))
                .Generate();
    }
}
