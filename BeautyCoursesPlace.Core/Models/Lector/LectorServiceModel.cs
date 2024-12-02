using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Lector
{
    public class LectorServiceModel
    {
        [Display(Name = "Telephone number")]
        public string Number { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
