using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Review
{
    public class CreateReviewViewModel
    {
        public int CourseId { get; set; }        // Идентификатор на курса
        public string Feedback
        {
            get; set;
        }
    }
}
