using StoreApi.Application.UseCases.Store;
using StoreApi.Communication.Store.Request;

namespace StoreApi.Application.Tests.Registro
{
    public class RegisterStoreUseCaseTests
    {
        [Fact]
        public void Success()
        {
            var validator = new StoreValidator();
            var request = new RequestStoreJson
            {
                Title = "Title",
                Address = "teste"
            };
            var result = validator.Validate(request);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Failure()
        {
            var validator = new StoreValidator();
            var request = new RequestStoreJson
            {
                Title = "",
                Address = ""
            };
            var result = validator.Validate(request);
            Assert.False(result.IsValid);
        }
    }
}
