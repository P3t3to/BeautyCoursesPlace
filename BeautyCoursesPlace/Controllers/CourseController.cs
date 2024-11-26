using BeautyCoursesPlace.Core.Models.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCoursesPlace.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllCoursesQueryModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyCourses()
        {

            var model = new AllCoursesQueryModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new CourseDetailsViewModel();
            return View(model); 

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CourseFormModel model)
        {
           
            return RedirectToAction(nameof(Details),new {id=1});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

          var model = new CourseFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CourseFormModel model)
        {

            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var model = new CourseDetailsViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CourseDetailsViewModel model)
        {

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(int id)
        {
            return RedirectToAction(nameof(MyCourses));
        }


        [HttpPost]
        public async Task<IActionResult> SignOff(int id)
        {
            return RedirectToAction(nameof(MyCourses));
        }

    }

    
}
