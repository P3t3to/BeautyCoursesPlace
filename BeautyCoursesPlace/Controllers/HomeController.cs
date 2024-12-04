using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BeautyCoursesPlace.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService courseService;

        public HomeController(ILogger<HomeController> logger,
            ICourseService _courseService)
        {

            _logger = logger;
            courseService = _courseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            var model = await courseService.LastThreeCoursesAsync();
            return View(model);
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode==400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
