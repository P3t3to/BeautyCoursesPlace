using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Review;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using BeautyCoursesPlace.Core.Services;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BeautyCoursesPlace.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly ICourseService courseService;
        private readonly UserManager<ApplicationUser> userManager;

        public ReviewController(IReviewService reviewService, ICourseService _courseService, UserManager<ApplicationUser> _userManager)
        {
            this.reviewService = reviewService;
            this.courseService = _courseService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Review()
        {
            var userId = User.Id();

            var courses = await courseService.GetSignedInCoursesAsync(userId); //Ако има записани курсове ги показва

            if (!courses.Any())
            {
                return RedirectToAction("All", "Course"); // Ако няма записани курсове, връща към списъка с курсове
            }

            return View(courses); // Показва курсовете за ревю
        }


        [HttpGet]
        public IActionResult AddReview(int id)
        {
            var model = new AddReviewViewModel //Добавя  ревю/opinion  за SignIn курс
            {
                CourseId = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await reviewService.AddReviewAsync(model, User.Id()); //Извежда се картичка с празно поле за писане
            
            return RedirectToAction("All", "Course");
        }

    }
}
