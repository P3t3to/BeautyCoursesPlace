using BeautyCoursesPlace.Core.Contracts.Course;
using BeautyCoursesPlace.Core.Models.Home;
using BeautyCoursesPlace.Core.Services.Course;
using BeautyCoursesPlace.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BeautyCoursesPlace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService courseService;

        public HomeController(ILogger<HomeController> logger,
            ICourseService _courseService)
        {

            _logger = logger;
            courseService = _courseService;
        }

        public async Task<IActionResult> Index()
        {

            var model = await courseService.LastThreeCourses();
            return View(model);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
