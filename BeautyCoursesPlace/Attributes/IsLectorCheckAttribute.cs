using BeautyCoursesPlace.Core.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BeautyCoursesPlace.Controllers;

namespace BeautyCoursesPlace.Attributes
{
    public class IsLectorCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            base.OnActionExecuting(context);

            ILectorService? lectorService = context.HttpContext.RequestServices.GetService<ILectorService>();

            if (lectorService == null)
            {
                context.Result = new StatusCodeResult(500);
            }
            if (lectorService != null && lectorService.ExistByIdAsync(context.HttpContext.User.Id()).Result==false)
            {

                context.Result = new RedirectToActionResult(nameof(LectorController.Become), "Lector", null);
            }
        }
    }
}

