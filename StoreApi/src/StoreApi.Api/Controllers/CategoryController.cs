using Microsoft.AspNetCore.Mvc;
using StoreApi.Application.UseCases.Category.Get;
using StoreApi.Application.UseCases.Category.Register;
using StoreApi.Communication.Category.Request;
using StoreApi.Communication.Category.Response;
using StoreApi.Communication.Erros;

namespace StoreApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterCategoryJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponsesErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
        [FromServices] IRegisterCategoryUseCase useCase,
        [FromBody] RequestCategoryJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ReponseCategories), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategory(
            [FromServices] IGetCategories useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }
    }
}
