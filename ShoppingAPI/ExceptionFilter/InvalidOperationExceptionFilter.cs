using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ShoppingAPI.ExceptionFilter
{
    public class InvalidOperationExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is InvalidOperationException httpResponseException)
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
