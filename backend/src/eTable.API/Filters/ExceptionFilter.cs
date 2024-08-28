using eTable.Communication.Responses;
using eTable.Exception.Exceptions;
using eTable.Exception.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace eTable.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is eTableException)
                HandleProjectException(context);
            else
                ThrowUnknowException(context);
        }
        
        private static void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            {
                var exception = context.Exception as ErrorOnValidationException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                context.Result = new BadRequestObjectResult(new ErrorResponseDTO(exception!.ErrorMessages));

            }
        }

        private static void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ErrorResponseDTO(ResourceMessageException.UNKNOW_ERROR));
        }
    }
}
