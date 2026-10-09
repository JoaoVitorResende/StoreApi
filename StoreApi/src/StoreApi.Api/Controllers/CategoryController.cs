using Microsoft.AspNetCore.Mvc;
using StoreApi.Application.UseCases.Category.Register;
using StoreApi.Communication.Category.Request;

namespace StoreApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(
       [FromServices] IRegisterCategoryUseCase useCase,
       [FromBody] RequestCategoryJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
