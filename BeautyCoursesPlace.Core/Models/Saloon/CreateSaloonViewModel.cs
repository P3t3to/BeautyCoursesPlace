using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Saloon
{
    public class CreateSaloonViewModel
    {
        [Required]
        [Display(Name = "Saloon Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Saloon Address")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Partner Name (if applicable)")]
        public string? PartnerName { get; set; }
    }
}
