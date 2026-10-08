using Microsoft.AspNetCore.Mvc;
using StoreApi.Application.UseCases.Itens.Register;
using StoreApi.Communication.Item.Request;

namespace StoreApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterItem([FromServices] IRegisterItemUseCase useCase, [FromBody] RequestItemJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItemById([FromServices] IGetItemById useCase, [FromRoute] long id)
        {
            var response = await useCase.Execute(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItem([FromServices] IDeleteItemUsecase useCase, [FromRoute] long id)
        {
            await useCase.Execute(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItem([FromServices] IUpdateItemUseCase useCase, [FromRoute] long id, [FromBody] RequestExpensesJson request)
        {
            await useCase.Execute(id, request);
            return NoContent();
        }
    }
}
