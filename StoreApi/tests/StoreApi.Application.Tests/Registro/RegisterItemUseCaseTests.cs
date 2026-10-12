using StoreApi.Application.UseCases.Itens;
using StoreApi.Communication.Item.Request;

namespace StoreApi.Application.Tests.Registro
{
    public class RegisterItemUseCaseTests
    {
        [Fact]
        public void Success()
        {
            var validator = new ItemValidator();
            var request = new RequestItemJson
            {
               Title = "teste",
               CategoryId = 1,
               Description = "Test",
               Price = 2,
               Quantity = 3,
               StoreId = 1,
            };

            var result = validator.Validate(request);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Failure()
        {
            var validator = new ItemValidator();
            var request = new RequestItemJson
            {
                Title = "",
                CategoryId = 1,
                Description = "Test",
                Price = 2,
                Quantity = 3,
                StoreId = 1,
            };

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
        }
    }
}