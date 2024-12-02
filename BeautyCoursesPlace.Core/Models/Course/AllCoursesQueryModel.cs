using BeautyCoursesPlace.Core.Enums;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Course
{
    public class AllCoursesQueryModel
    {
        public  int CoursesPerPage { get;  } = 3;

        public string Category { get; init; } = null!;

        [Display(Name="Search key word")]
        public string SearchItem { get; init; } = null!;

        public CourseSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalCoursesCount { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable <CourseServiceModel> Courses { get; set; } = new List<CourseServiceModel>(); 
    }
}
