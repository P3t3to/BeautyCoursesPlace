using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Review
{
    public class CourseReviewViewModel
    {
        public string Feedback { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; } = null!;


    }

}
