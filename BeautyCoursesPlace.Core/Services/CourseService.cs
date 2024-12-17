using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Enums;
using BeautyCoursesPlace.Core.Exeptions;
using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Core.Models.Home;
using BeautyCoursesPlace.Infrastructure.Data.Common;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
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

            if (searchTime != null)
            {

                string normalizedSearchTime = searchTime.ToLower();

                coursesToDisplay = coursesToDisplay
                    .Where(c => (c.Title.ToLower().Contains(normalizedSearchTime) ||
                              c.Address.ToLower().Contains(normalizedSearchTime) ||
                              c.Description.ToLower().Contains(normalizedSearchTime)));
            }

            coursesToDisplay = sorting switch
            {
                CourseSorting.Price => coursesToDisplay.OrderBy(c => c.Cost),
                CourseSorting.FistSignIn => coursesToDisplay.OrderBy(c => c.StudentId != null).ThenByDescending(c => c.Id),
                _ => coursesToDisplay.OrderByDescending(c => c.Id),
            };


            var courses = await coursesToDisplay
                .Skip((currentPage - 1) * coursesPerPage)
                .Take(coursesPerPage)
                .ProjectCoursesServiceModel()
                .ToListAsync();

            int totalCourses = await coursesToDisplay.CountAsync();

            return new CourseQueryServiceModel()
            {
                Courses = courses,
                TotalCoursesCount = totalCourses
            };
        }

        public async Task<IEnumerable<string>> AllCategoriesNameAsync()
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseCategoryServiceModel>> AllCategoryAsync()
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Category>()
                .Select(c => new CourseCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,

                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseServiceModel>> AllCoursesByLectorIdAsync(int lectorId)
        {
            return await repository.AllReadOnly<Course>()
                 .Where(c => c.LectorId == lectorId)
                 .ProjectCoursesServiceModel()
                 .ToListAsync();
        }

        public async Task<IEnumerable<CourseServiceModel>> AllCoursesByUserId(string userId)
        {
            return await repository.AllReadOnly<Course>()
                 .Where(c => c.StudentId == userId)
                 .ProjectCoursesServiceModel()
                 .ToListAsync();
        }

        public async Task<bool> CategoryCreatedAsync(int categoryId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<CourseDetailServiceModel> CourseDetailsbyIdAsync(int id)
        {
            return await repository.AllReadOnly<Course>()
                 .Where(c => c.Id == id)
                 .Select(c => new CourseDetailServiceModel()
                 {
                     Id = c.Id,
                     Address = c.Address,
                     Lector = new Models.Lector.LectorServiceModel()
                     {
                         Email = c.Lector.User.Email,
                         Number = c.Lector.Telephone
                     },
                     Category = c.Category.Name,
                     Description = c.Description,
                     ImageUrl = c.ImageUrl,
                     IsSignIn = c.StudentId != null,
                     CostCourse = c.Cost,
                     Title = c.Title,

                 })
                 .FirstAsync();

        }

        public async Task DeleteAsync(int courseId)
        {

            await repository.DeleteAsync<Course>(courseId);
            await repository.SaveChangesAsync();
        }

        public async Task Edit(int courseId, CourseFormModel model)
        {
            var course = await repository.GetByIdAsync<Course>(courseId);


            if (course != null)
            {
                course.Address = model.Address;
                course.CategoryId = model.CategoryId;
                course.Description = model.Description;
                course.ImageUrl = model.ImageUrl;
                course.Cost = model.Cost;
                course.Title = model.Title;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllReadOnly<Course>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<bool> HasLectorWithIdAsync(int courseId, string userId)
        {
            return await repository.AllReadOnly<Course>()
              .AnyAsync(h => h.Id == courseId && h.Lector.UserId == userId);
        }

        public async Task<bool> IsSigninAsync(int courseId)
        {
            bool result = false;

            var course = await repository.GetByIdAsync<Course>(courseId);

            if (course != null)
            {
                result = course.StudentId != null;
            }

            return result;
        }

        public async Task<bool> IsSignoutByUserAsync(int courseId, string userid)
        {
            bool result = false;

            var course = await repository.GetByIdAsync<Course>(courseId);

            if (course != null)
            {
                result = course.StudentId == userid;
            }

            return result;
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
                    Address = c.Address,
                    ImageUrl = c.ImageUrl,
                    Title = c.Title,

                }).ToListAsync();
        }

        public async Task<int> MakeOnAsync(CourseFormModel model, int lectorId)
        {
            Course course = new Course()
            {
                Address = model.Address,
                LectorId = lectorId,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Title = model.Title,
                Cost = model.Cost,


            };

            await repository.AddAsync(course);
            await repository.SaveChangesAsync();

            return course.Id;
        }

        public async Task<CourseFormModel?> RecieveCourseFormodelAsync(int id)
        {
            var course = await repository.AllReadOnly<Course>()
                .Where(c => c.Id == id)
                .Select(c => new CourseFormModel()
                {
                    Address = c.Address,
                    CategoryId = c.CategoryId,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    Cost = c.Cost,
                    Title = c.Title,

                })
                .FirstOrDefaultAsync();

            if (course != null)
            {
                course.Categories = await AllCategoryAsync();
            }

            return course;
        }

        public async Task SignInMeAsync(int id, string userid)
        {


            var course = await repository.GetByIdAsync<Course>(id);

            if (course != null)
            {
                course.StudentId = userid;
                await repository.SaveChangesAsync();

            }
        }

        public async Task SignMeOutAsync(int courseid, string userId)
        {
            var course = await repository.GetByIdAsync<Course>(courseid);

            if (course != null)
            {
                if (course.StudentId != userId)
                {
                    throw new UnauthorizedExeption("You are not permited to Sign out, you did not Signed in.");
                }


                course.StudentId = null;
                await repository.SaveChangesAsync();

            }
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            // Викаме метода от репозитория и връщаме резултата като List
            return await repository.All<Course>().ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await repository.GetByIdAsync<Course>(courseId);
        }


        public interface ICourseService
        {
            Task<IEnumerable<CourseViewModel>> GetSignedInCoursesAsync(string userId);
        }

        public async Task<IEnumerable<CourseViewModel>> GetSignedInCoursesAsync(string userId)
        {
            var courses = await repository.Courses.ToListAsync();

            // Филтриране в паметта на тези, в които потребителят е записан
            var signedInCourses = courses
                .Where(c => !string.IsNullOrEmpty(c.StudentId) && c.StudentId.Split(',').Contains(userId))
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl
                });

            return signedInCourses;
        }
    }
}
