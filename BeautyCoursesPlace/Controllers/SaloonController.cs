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
                    return Unauthorized(); 
                }

                var saloonModel = new SaloonViewModel
                {
                    Name = model.Name,
                    Address = model.Address
                };

                
                var saloonId = await saloonService.CreateSaloonAsync(saloonModel, userId);

               
                return RedirectToAction("SaloonDetails", new { id = saloonId });
            }

            return View("CreateSaloonView", model); 
        }

        public async Task<IActionResult> SaloonDetails(int id)
        {
           
            var saloon = await saloonService.GetSaloonByIdAsync(id);

         
            if (saloon == null)
            {
                return NotFound(); 
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


