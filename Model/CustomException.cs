using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Airlines.Model
{
    public class CustomException :IExceptionFilter
    {
    

        public void OnException(ExceptionContext context)
        {
            Error customException = new Error()
            {
                StatusCode = 500,
                Message = context.Exception.Message

            };
            context.Result=new JsonResult(customException);
        }
    }
}
