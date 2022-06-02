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
            if(context.Exception is BadRequestException)
            {
                var exception = context.Exception as BadRequestException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(new
                {
                    success = false,
                    Message = exception!.Message,
                    Errors = exception.Errors
                });
            }

            if (context.Exception is NotFoundRequestException)
            {
                var exception = context.Exception as NotFoundRequestException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new JsonResult(new
                {
                    success = false,
                    Message = exception!.Message,
                });
            }
        }
    }
}
