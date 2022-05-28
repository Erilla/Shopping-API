using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ShoppingAPI.ExceptionFilter
{
    public class ArgumentExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ArgumentException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Message)
                {
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
