using BeautyCoursesPlace.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BeautyCoursesPlace.Attributes
{
    public class NotLectorAttribute:ActionFilterAttribute
    {
   
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            base.OnActionExecuting(context);

            ILectorService? lectorService= context.HttpContext.RequestServices.GetService<ILectorService>(); 

            if(lectorService == null )
            {
                context.Result= new StatusCodeResult(500);
            }
            if(lectorService !=null && lectorService.ExistByIdAsync(context.HttpContext.User.Id()).Result)
            {

                context.Result=new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
