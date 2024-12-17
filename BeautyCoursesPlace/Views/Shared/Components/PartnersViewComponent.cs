using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Partner;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BeautyCoursesPlace.Views.Shared.Components
{
    public class PartnersViewComponent: ViewComponent
    {
        private readonly IPartnerService _partnerService;

        public PartnersViewComponent(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Извличане на всички партньори от сервиза
            var partners = await _partnerService.GetAllPartnersAsync();

            // Преобразуване в PartnerViewModel
            var partnerViewModels = partners.Select(p => new PartnerViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl
            }).ToList();

            // Връщане на изглед с данните
            return View("_FooterPartners", partnerViewModels);
        }
    }
}

