using Microsoft.AspNetCore.Mvc;
using StoreApi.Application.UseCases.Store.GetAll;
using StoreApi.Application.UseCases.Store.GetByName;
using StoreApi.Application.UseCases.Store.Register;
using StoreApi.Communication.Erros;
using StoreApi.Communication.Store.Request;
using StoreApi.Communication.Store.Response;

namespace StoreApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseStoreJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponsesErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
        [FromServices] IRegisterStoreUseCase useCase,
        [FromBody] RequestStoreJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("{storeName}")]
        [ProducesResponseType(typeof(ResponseStoreJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponsesErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponsesErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStoreByName(
        [FromServices] IGetStoreByName useCase,
        [FromRoute] string storeName)
        {
            var response = await useCase.Execute(storeName);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseStoreJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
        [FromServices] IGetStoreAll useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }
    }
}
