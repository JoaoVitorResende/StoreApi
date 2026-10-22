using StoreApi.Application.Tests.Utils;
using StoreApi.Application.UseCases.Itens;

namespace StoreApi.Application.Tests.Registro
{
    public class RegisterItemUseCaseTests
    {
        [Fact]
        public void Success()
        {
            var validator = new ItemValidator();
            var request = RequestBuilders.Item();

            var result = validator.Validate(request);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Error_Title_Invalid(string? title)
        {
            var validator = new ItemValidator();
            var request = RequestBuilders.Item();
            request.Title = title!;

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void Volume_Test_10000_Requests()
        {
            var validator = new ItemValidator();
            var requests = Enumerable.Range(0, 10_000).Select(_ => RequestBuilders.Item()).ToList();

            var sw = System.Diagnostics.Stopwatch.StartNew();
            var results = requests.Select(r => validator.Validate(r)).ToList();
            sw.Stop();

            Assert.All(results, r => Assert.True(r.IsValid));
            Assert.True(sw.ElapsedMilliseconds < 5000);
        }
    }
}