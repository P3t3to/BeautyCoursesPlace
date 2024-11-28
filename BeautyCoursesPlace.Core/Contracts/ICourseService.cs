using BeautyCoursesPlace.Core.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Contracts
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseIndexServiceModel>> LastThreeCoursesAsync();
    }
}
