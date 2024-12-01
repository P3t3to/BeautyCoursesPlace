using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Core.Models.Home;
using BeautyCoursesPlace.Infrastructure.Data.Common;
using BeautyCoursesPlace.Infrastructure.Data.Models;
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

        public async Task<IEnumerable<CourseCategoryServiceModel>> AllCategoryAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new CourseCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,

                })
                .ToListAsync();
        }

        public async Task<bool> CategoryCreatedAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<IEnumerable<CourseIndexServiceModel>> LastThreeCoursesAsync()
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

        public async Task<int> MakeOnAsync(CourseFormModel model, int lectorId)
        {
            Course course = new Course()
            {
                Address= model.Address,
                LectorId=lectorId,
                CategoryId=model.CategoryId,
                Description=model.Description,
                ImageUrl=model.ImageUrl,
                Title=model.Title,
                Cost=model.Cost,


            };

            await repository.AddAsync(course);
            await repository.SaveChangesAsync();

            return course.Id;
        }
    }
}
