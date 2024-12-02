using BeautyCoursesPlace.Attributes;
using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Outlook;
using System.Security.Claims;

namespace BeautyCoursesPlace.Controllers
{
    
    public class CourseController : BaseController
    {
        private readonly ICourseService courseService;

        private readonly ILectorService lectorService;
        public CourseController
            (ICourseService _courseService,
            ILectorService _lectorService)
        {
            courseService = _courseService;
            lectorService = _lectorService;
        }

        


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllCoursesQueryModel model)
        {
            var courses = await courseService.AllAsync(
                model.Category,
                model.SearchItem,
                model.Sorting,
                model.CurrentPage,
                model.CoursesPerPage
                );


            model.TotalCoursesCount = courses.TotalCoursesCount;
            model.Courses = courses.Courses;
            model.Categories = await courseService.AllCategoriesNameAsync();


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyCourses()
        {

            var userId = User.Id();

            IEnumerable<CourseServiceModel> model;

            if (await lectorService.ExistByIdAsync(userId))
            {
               int lectorId = await lectorService.GiveLectorIdAsync(userId) ?? 0;
                model = await courseService.AllCoursesByLectorIdAsync(lectorId);
            }
            else
            {

                model=await courseService.AllCoursesByUserId(userId);
            }
            

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await courseService.ExistAsync(id)==false)
            {
                return BadRequest();
            }

            var model = await courseService.CourseDetailsbyIdAsync(id);

            return View(model); 

        }

        [HttpGet]
        [IsLectorCheck]
        public async Task<IActionResult>Add()
        {
            
            var model=new CourseFormModel()
            {

                Categories= await courseService.AllCategoryAsync()
            };

            return View(model);
        }

        [HttpPost]
        [IsLectorCheck]
        public async Task<IActionResult> Add(CourseFormModel model)
        {
            if(await courseService.CategoryCreatedAsync(model.CategoryId)==false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "");
            }  

            if(ModelState.IsValid==false)
            {
                model.Categories = await courseService.AllCategoryAsync();

                return View(model);

            }
           
            int? lectorId = await lectorService.GiveLectorIdAsync(User.Id());

            int newCourseId = await courseService.MakeOnAsync(model, lectorId ?? 0);

            return RedirectToAction(nameof(Details),new {id=newCourseId});
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
