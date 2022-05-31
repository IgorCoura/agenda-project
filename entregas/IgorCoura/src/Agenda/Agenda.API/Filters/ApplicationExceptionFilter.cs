using System.Net;
using Agenda.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Agenda.API.Filters
{
    public class ApplicationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is DomainException)
            {
                var exception = context.Exception as DomainException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(new
                {
                    success = false,
                    Message = exception!.Message,
                    Errors = exception.Errors
                });
            }
        }
    }
}
