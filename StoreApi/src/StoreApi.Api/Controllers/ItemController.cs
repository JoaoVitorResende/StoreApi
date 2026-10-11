using Microsoft.AspNetCore.Mvc;
using StoreApi.Application.UseCases.Itens.GetAll;
using StoreApi.Application.UseCases.Itens.GetByID;
using StoreApi.Application.UseCases.Itens.Register;
using StoreApi.Communication.Erros;
using StoreApi.Communication.Item.Request;
using StoreApi.Communication.Item.Response;

namespace StoreApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterItemJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponsesErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterItem([FromServices] IRegisterItemUseCase useCase, [FromBody] RequestItemJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseItens), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllItens([FromServices] IGetAllItens useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseItemJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponsesErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItemById(
            [FromServices] IGetItemByID useCase, [FromRoute] string id)
        {
            var response = await useCase.Execute(id);
            return Ok(response);
        }
    }
}
