using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeautyCoursesPlace.Core.Constants.MessageConstants;
using static BeautyCoursesPlace.Infrastructure.Constants.DataConstants;

namespace BeautyCoursesPlace.Core.Models.Lector
{
    public class BecomeLectorFormModel
    {
        [Required(ErrorMessage = FillInMessage)]
        [StringLength(TelephoneMaxLength, MinimumLength =TelephoneMinLength, ErrorMessage =TelephoneMessage)]
        [Display(Name ="Telephone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
