using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IQuerableCourseExtensions
    {
        public static IQueryable<CourseServiceModel> ProjectCoursesServiceModel(this IQueryable<Course> courses)
        {
            return courses
                   .Select(c => new CourseServiceModel()
                   {
                       Id=c.Id,
                       Address=c.Address,
                       ImageUrl=c.ImageUrl,
                       IsSignIn=c.StudentId !=null,
                       CostCourse=c.Cost,
                       Title=c.Title,

                   });
                
        }
    }
}
