using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ProjectV2.Common.Exceptions
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ApiException apiException)
            {
                Console.WriteLine(apiException.Message);
                context.Result = new ObjectResult(apiException.Message) { StatusCode = (int)apiException.Code };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is Exception e)
            {
                context.Result = new ObjectResult(e.Message) { StatusCode = 500 };
                context.ExceptionHandled = true;
            }
        }
    }
}
