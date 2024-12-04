using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Course
{
    public class CourseDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Address { get; set; }=string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
