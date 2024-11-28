using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Lector;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            if (await lectorService.ExistByIdAsync(User.Id()))
            {
                return BadRequest("You are already registered as a lecturer.");
            }

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

