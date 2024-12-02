using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Enums;
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

        public async Task<CourseQueryServiceModel> AllAsync(string? category = null, string? searchTime = null, CourseSorting sorting = CourseSorting.Newest, int currentPage = 1, int coursesPerPage = 1)
        {
            var coursesToDisplay = repository.AllReadOnly<Course>();

            if (category != null)
            {
                coursesToDisplay = coursesToDisplay
                    .Where(c => c.Category.Name == category);
            }

            if (searchTime != null )
            {

                string normalizedSearchTime = searchTime.ToLower();

                coursesToDisplay = coursesToDisplay
                    .Where(c => (c.Title.ToLower().Contains(normalizedSearchTime)  ||
                              c.Address.ToLower().Contains(normalizedSearchTime) ||
                              c.Description.ToLower().Contains(normalizedSearchTime)));
            }

            coursesToDisplay = sorting switch
            {
                CourseSorting.Price=> coursesToDisplay.OrderBy(c=>c.Cost),
                CourseSorting.FistSignIn=> coursesToDisplay.OrderBy(c=>c.StudentId !=null).ThenByDescending(c=>c.Id),
                 _ =>coursesToDisplay.OrderByDescending(c => c.Id),
            };


            var courses = await coursesToDisplay
                .Skip((currentPage - 1) * coursesPerPage)
                .Take(coursesPerPage)
                .Select(c => new CourseServiceModel()
                {
                    Id=c.Id,
                    Address=c.Address,
                    ImageUrl=c.ImageUrl,
                    IsSignIn = c.StudentId !=null,
                    CostCourse=c.Cost,
                    Title=c.Title


                }).ToListAsync();

            int totalCourses= await coursesToDisplay.CountAsync();

            return new CourseQueryServiceModel()
            {
                Courses = courses,
                TotalCoursesCount = totalCourses
            };
        }

        public async Task<IEnumerable<string>> AllCategoriesNameAsync()
        {
           return await repository.AllReadOnly<Category>()
               .Select(c=>c.Name)
               .Distinct()
               .ToListAsync();
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
