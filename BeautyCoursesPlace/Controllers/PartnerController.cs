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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var partner = await partnerService.GetPartnerByIdAsync(id);
            if (partner == null)
            {
                return NotFound();
            }

            var partnerViewModel = new PartnerViewModel
            {
                Id = partner.Id,
                Name = partner.Name,
                Address = partner.Address,
                ImageUrl = partner.ImageUrl,
                Courses = partner.Courses.Select(c => c.Title).ToList(),
                Saloons = partner.Saloons.Select(s => s.Name).ToList()
            };

            return View(partnerViewModel);
        }

    }

}
