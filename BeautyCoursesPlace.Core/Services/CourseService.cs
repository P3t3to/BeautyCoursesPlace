using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Home;
using BeautyCoursesPlace.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository repository;

        public CourseService(IRepository _repository)
        {
            repository = _repository;

        }
        public async Task<IEnumerable<CourseIndexServiceModel>> LastThreeCourses()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.Course>()
                .OrderByDescending(c => c.Id)
                .Take(3)
                .Select(c => new CourseIndexServiceModel()
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Title = c.Title,

                }).ToListAsync();
        }
    }
}
