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
                    Errors = exception!.Errors.Select(x => x.ErrorMessage)
                });
            }

            if (context.Exception is NotFoundRequestException)
            {
                var exception = context.Exception as NotFoundRequestException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new JsonResult(new
                {
                    success = false,
                    Errors = new string[1] {exception!.Message},
                });
            }

            if (context.Exception is NotAuthorizedException)
            {
                var exception = context.Exception as NotAuthorizedException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new
                {
                    success = false,
                    Errors = new string[1] { exception!.Message },
                });
            }
        }
    }
}
