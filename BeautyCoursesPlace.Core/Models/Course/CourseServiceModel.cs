using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static BeautyCoursesPlace.Infrastructure.Constants.DataConstants;
using static BeautyCoursesPlace.Core.Constants.MessageConstants;

namespace BeautyCoursesPlace.Core.Models.Course
{
    public class CourseServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = FillInMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TelephoneMessage)]
        public string Title { get; set; }=string.Empty;

       
        [Required(ErrorMessage = FillInMessage)]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = TelephoneMessage)]
        public string Address { get; set; }=string.Empty;


        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = string.Empty;


        [DisplayName("Course price")]
        [Range(typeof(decimal), "0,00", "5000,00", ConvertValueInInvariantCulture = true
            , ErrorMessage = "Cost must be between 0.00 and 5000.00.")]
       
        public decimal CostCourse { get; set; }


        [DisplayName("Are you signed in")]
        public bool IsSignIn { get; set; } 
    }
}