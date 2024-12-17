using BeautyCoursesPlace.Attributes;
using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Exeptions;
using BeautyCoursesPlace.Core.Extensions;
using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Core.Services;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Outlook;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Security.Claims;

namespace BeautyCoursesPlace.Controllers
{
    
    public class CourseController : BaseController
    {
        private readonly ICourseService courseService;

        private readonly ILectorService lectorService;

        private readonly ILogger logger;    
        public CourseController
            (ICourseService _courseService,
            ILectorService _lectorService
,            ILogger<CourseController>_logger)
        {
            courseService = _courseService;
            lectorService = _lectorService;
            logger = _logger;
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
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await courseService.ExistAsync(id)==false)
            {
                return BadRequest();
            }

            

            var model = await courseService.CourseDetailsbyIdAsync(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

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
                ModelState.AddModelError(nameof(model.CategoryId), "There is not such Category");
            }  

            if(ModelState.IsValid==false)
            {
                model.Categories = await courseService.AllCategoryAsync();

                return View(model);

            }
           
            int? lectorId = await lectorService.GiveLectorIdAsync(User.Id());

            int newCourseId = await courseService.MakeOnAsync(model, lectorId ?? 0);

            return RedirectToAction(nameof(Details),new {id=newCourseId, information =model.GetInformation() });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if (await courseService.ExistAsync(id) ==false)
            {
                return BadRequest();
            }

            if (await courseService.HasLectorWithIdAsync(id, User.Id()) == false
                && User.IsAdmin()==false)
            {
                return Unauthorized("You do not have permission to edit this course.");

            }

           var model = await courseService.RecieveCourseFormodelAsync(id);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, CourseFormModel model)
        {


            if (await courseService.ExistAsync(id) == false)
            {
                return BadRequest("Course does not exist.");
            }

            if (await courseService.HasLectorWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized("You do not have permission to edit this course.");

            }

            if (await courseService.CategoryCreatedAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "There is not such Category");
            }

            if (ModelState.IsValid==false)
            {
                model.Categories = await courseService.AllCategoryAsync();
                return View(model);
            }

            await courseService.Edit(id, model);
            return RedirectToAction(nameof(Details), new {id, information = model.GetInformation()});
        }

       

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            
            if (await courseService.ExistAsync(id) == false)
            {
                return BadRequest("Course does not exist.");
            }

     
            if (await courseService.HasLectorWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized("You do not have permission to delete this course.");
            }

            var course = await courseService.CourseDetailsbyIdAsync(id);
            if (course == null)
            {
                return NotFound("Course details could not be loaded.");
            }

         
            var model = new CourseDetailsViewModel()
            {
                Id = course.Id,
                Address = course.Address,
                ImageUrl = course.ImageUrl,
                Title = course.Title
            };

            return View(model);
        }
        

        [HttpPost]
        public async Task<IActionResult> SignUp(int id)
        {
            if (await courseService.ExistAsync(id) == false)
            {
                return BadRequest("Course does not exist.");
            }

            await courseService.SignInMeAsync(id, User.Id());
            return RedirectToAction(nameof(All));
        }


        [HttpPost]
        public async Task<IActionResult> SignOff(int id)
        {
            if (await courseService.ExistAsync(id) == false)
            {
                return BadRequest("Course does not exist.");
            }
            try
            {
                await courseService.SignMeOutAsync(id, User.Id());
            }
            catch(UnauthorizedExeption msg)
            {

                logger.LogError(msg, "CourseController.SignMeOut");
                return Unauthorized();
            }

                       
            return RedirectToAction(nameof(All));
        }

    }

    
}
