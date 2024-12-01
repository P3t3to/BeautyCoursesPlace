using BeautyCoursesPlace.Attributes;
using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Lector;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static BeautyCoursesPlace.Core.Constants.MessageConstants;

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
        [NotLector]
        public IActionResult Become()
        {
           
            var model = new BecomeLectorFormModel();

            return View(model);
        }

        [HttpPost]
        [NotLector]
        public async Task<IActionResult> Become(BecomeLectorFormModel model)
        {
            if(await lectorService.ClientPhoneNumberExistAsync(model.PhoneNumber))

            {
                ModelState.AddModelError(nameof(model.PhoneNumber), TelephoneAlreadyRegistered);

            }

            if(await lectorService.ClientSignInAsync(User.Id())) 
            {
                ModelState.AddModelError("Error", SignInCourse);

            }

            
            if (ModelState.IsValid ==false)
            {
                return View(model);
            }

            await lectorService.InitiateAsync(User.Id(), model.PhoneNumber);

            return RedirectToAction(nameof(CourseController.All), "Course");
        }
    }
}

