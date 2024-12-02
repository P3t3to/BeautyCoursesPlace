using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Course
{
    public class CourseQueryServiceModel
    {
        public int TotalCoursesCount { get; set; }

        public IEnumerable<CourseServiceModel> Courses{ get; set; } = new List<CourseServiceModel>();
    }
}
