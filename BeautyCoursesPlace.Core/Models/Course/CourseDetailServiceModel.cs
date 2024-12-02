using BeautyCoursesPlace.Core.Models.Lector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Course
{
    public class CourseDetailServiceModel:CourseServiceModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; }

        public LectorServiceModel Lector  { get; set; } = null!;
    }
}
