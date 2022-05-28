using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.Entity.Core;
using System.Net;

namespace ShoppingAPI.ExceptionFilter
{
    public class ObjectNotFoundExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ObjectNotFoundException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Message)
                {
                    StatusCode = (int?)HttpStatusCode.NotFound
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
