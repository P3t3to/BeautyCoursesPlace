using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeautyCoursesPlace.Core.Constants.MessageConstants;
using static BeautyCoursesPlace.Infrastructure.Constants.DataConstants;

namespace BeautyCoursesPlace.Core.Models.Course
{
    public class CourseFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = FillInMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,ErrorMessage = TelephoneMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = FillInMessage)]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = TelephoneMessage)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = FillInMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = TelephoneMessage)]
        public string Description   { get; set; } = null!;

        [Required(ErrorMessage = FillInMessage)]
        [DisplayName("Image Url")]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), "0,00", "5000,00", ConvertValueInInvariantCulture=true
            ,ErrorMessage= "Cost must be between 0.00 and 5000.00.")]    
        public decimal Cost { get; set; }

        [DisplayName("Course Category")]
        public int CategoryId { get; set; }

        public IEnumerable <CourseCategoryServiceModel> Categories{ get; set; }=new List<CourseCategoryServiceModel>();
    }
}
