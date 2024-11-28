using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Lector;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCoursesPlace.Controllers
{
    
    public class LectorController : BaseController
    {
        private readonly ILectorService lectorService;
        public LectorController(ILectorService _lectorService)
        {
            lectorService = _lectorService;
        }

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

