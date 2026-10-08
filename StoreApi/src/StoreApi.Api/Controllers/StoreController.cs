using Microsoft.AspNetCore.Mvc;
using StoreApi.Application.UseCases.Store.Register;
using StoreApi.Communication.Store.Request;

namespace StoreApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(
        [FromServices] IRegisterStoreUseCase useCase,
        [FromBody] RequestStoreJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
