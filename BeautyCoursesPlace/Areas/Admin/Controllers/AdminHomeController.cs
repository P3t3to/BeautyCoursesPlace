using Microsoft.AspNetCore.Mvc;

namespace BeautyCoursesPlace.Areas.Admin.Controllers
{
    public class AdminHomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
