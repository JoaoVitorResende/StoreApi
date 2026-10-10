using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreApi.Communication.Erros;
using StoreApi.Exception.ExceptionBase;

namespace StoreApi.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is StoreApiException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnkowError(context);
            }
        }

        public void HandleProjectException(ExceptionContext context)
        {
            var storeApiException = (StoreApiException)context.Exception;
            var errorResponse = new ResponsesErrorJson(storeApiException.GetErros());

            context.HttpContext.Response.StatusCode = storeApiException.StatusCode;
            context.Result = new BadRequestObjectResult(errorResponse);
        }

        public void ThrowUnkowError(ExceptionContext context)
        {
            var errorResponse = new ResponsesErrorJson("Erro desconhecido");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
