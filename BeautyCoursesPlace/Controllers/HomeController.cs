using BeautyCoursesPlace.Core.Models.Home;
using BeautyCoursesPlace.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BeautyCoursesPlace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            return View(model);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
