using BeautyCoursesPlace.Core.Models.Lector;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCoursesPlace.Controllers
{
    [Authorize]
    public class LectorController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            var model = new BecomeLectorFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeLectorFormModel model)
        {
            return RedirectToAction(nameof(CourseController.All), "Course");
        }
    }
}

