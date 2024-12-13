using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Saloon;
using BeautyCoursesPlace.Core.Services;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BeautyCoursesPlace.Controllers
{
    public class SaloonController : Controller
    {
        private readonly ISaloonService saloonService;


        public SaloonController(ISaloonService _saloonService)
        {
            saloonService = _saloonService;
        }



        public async Task<IActionResult> Index()
        {
            string userId = GetCurrentUserId();  // Получавате userId от текущия потребител

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();  // Ако няма идентифициран потребител
            }

            bool hasSaloon = await saloonService.UserHasSaloonAsync(userId);  // Проверявате дали има салон

            ViewData["UserHasSaloon"] = hasSaloon;

            if (!hasSaloon)
            {
                return RedirectToAction("Create");  // Пренасочвате към създаване на салон
            }

            return View();
        }


        // Действие за създаване на нов салон
        public IActionResult Create()
        {
            return View("CreateSaloonView");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSaloonViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = GetCurrentUserId();

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized(); // Ако няма идентифициран потребител
                }

                var saloonModel = new SaloonViewModel
                {
                    Name = model.Name,
                    Address = model.Address
                };

                // Създаване на салона без да получаваме резултат
                var saloonId = await saloonService.CreateSaloonAsync(saloonModel, userId);

                // Пренасочване към новото изглед за детайли на салона
                return RedirectToAction("SaloonDetails", new { id = saloonId });
            }

            return View("CreateSaloonView", model); // Връщаме обратно ако има грешки в данните
        }

        public async Task<IActionResult> SaloonDetails(int id)
        {
            // Вземане на салона с подаденото ID
            var saloon = await saloonService.GetSaloonByIdAsync(id);

            // Ако салонът не бъде намерен
            if (saloon == null)
            {
                return NotFound(); // Връщаме NotFound ако няма такъв салон
            }

            var saloonViewModel = new SaloonViewModel
            {
                Id = saloon.Id,
                Name = saloon.Name,
                Address = saloon.Address
            };

            return View(saloonViewModel);
        }






        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }



    }
}


