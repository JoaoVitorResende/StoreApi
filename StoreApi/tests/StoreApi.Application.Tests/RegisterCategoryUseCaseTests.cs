using StoreApi.Application.UseCases.Category;
using StoreApi.Communication.Category.Request;

namespace StoreApi.Application.Tests
{
    public class RegisterCategoryUseCaseTests
    {
        [Fact]
        public void Success()
        {
            var validator = new CategoryValidator();
            var request = new RequestCategoryJson
            {
                 Name = "name",
            };
            var result = validator.Validate(request);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Failure()
        {
            var validator = new CategoryValidator();
            var request = new RequestCategoryJson
            {
                Name = "",
            };
            var result = validator.Validate(request);
            Assert.False(result.IsValid);
        }
    }
}
