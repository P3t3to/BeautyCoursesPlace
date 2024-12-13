using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Partner;
using BeautyCoursesPlace.Core.Services;
using BeautyCoursesPlace.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeautyCoursesPlace.Attributes;
using BeautyCoursesPlace.Core.Exeptions;
using BeautyCoursesPlace.Core.Extensions;
using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Core.Services;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.Office.Interop.Outlook;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Security.Claims;

namespace BeautyCoursesPlace.Controllers
{
    public class PartnerController : Controller
    {
        private readonly ICourseService courseService;

        private readonly ILectorService lectorService;

        private readonly ILogger logger;

        private readonly IPartnerService partnerService;

        public PartnerController
            (ICourseService _courseService,
            ILectorService _lectorService
            , ILogger<CourseController> _logger,
            IPartnerService _partnerService)
        {
            courseService = _courseService;
            lectorService = _lectorService;
            logger = _logger;
            partnerService = _partnerService;
        }

        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            try

            {
                
                var partners = await partnerService.FooterPartners();

                
                ViewData["Partners"] = partners;

                return View();
            }
            catch (System.Exception ex)

            {

               

                return StatusCode(500, "Грешка при зареждане на партньорите");

            }
        }


        //public async Task<IActionResult> FooterPartners()
        //{
        //    var partners = await partnerService.FooterPartners();

        //    return PartialView("_FooterPartners", partners);
        //}





        //public async Task<IActionResult> FooterPartners()
        //{
        //    var partners = await partnerService.FooterPartners();

        //    if (!partners.Any())
        //    {
        //        Console.WriteLine("No partners available in the controller.");
        //    }

        //    return PartialView("_FooterPartners", partners);
        //}



        //public async Task<IActionResult> FooterPartners()
        //{
        //    var partners = await context.Partners
        //        .Select(p => new PartnerViewModel
        //        {
        //            Name = p.Name,
        //            ImageUrl = p.ImageUrl
        //        })
        //        .ToListAsync();

        //    // Проверка дали партньорите са извлечени правилно
        //    if (partners == null || !partners.Any())
        //    {
        //        Console.WriteLine("No partners found.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Found {partners.Count} partner(s).");
        //    }

        //    return PartialView("_FooterPartners", partners);  // Уверете се, че изпращате партньорите на частичния изглед
        //}






        //[Httpget]
        //[AllowAnonymous]
        //public async Task<IActionResult> Footerpartners()
        //{
        //    var partners = await context.partners
        //        .select(p => new partnerviewmodel
        //        {
        //            name = p.name,
        //            imageurl = p.imageurl
        //        })
        //        .tolistasync();

        //    return partialview("_footerpartners", partners);
        //}









        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> FooterPartners()
        //{
        //    var partners = await context.Partners
        //        .Select(p => new PartnerViewModel
        //        {
        //            Name = p.Name,
        //            ImageUrl = p.ImageUrl
        //        })
        //        .ToListAsync();

        //    // Логиране на партньорите, за да проверите дали се зареждат правилно
        //    if (partners == null || !partners.Any())
        //    {
        //        // Можете да добавите логиране в конзолата или лог файл
        //        Console.WriteLine("No partners found in the database.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Found {partners.Count} partners.");
        //    }

        //    return PartialView("_FooterPartners", partners);
        //}
    }

    internal class HttpgetAttribute : Attribute
    {
    }
}
