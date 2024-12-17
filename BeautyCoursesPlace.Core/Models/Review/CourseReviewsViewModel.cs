using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Review
{
    public class CourseReviewsViewModel
    {
        public int CourseId { get; set; } 
        public string CourseName { get; set; } = null!; 
        public List<CourseReviewViewModel> Reviews { get; set; } = new List<CourseReviewViewModel>(); 
    }
}
