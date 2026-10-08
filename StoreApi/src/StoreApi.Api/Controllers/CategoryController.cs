using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Application.UseCases.Category.Register;

namespace StoreApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(
       [FromServices] IRegisterCategoryUseCase useCase,
       [FromBody] RegisterCategoryUseCase request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
