using BeautyCoursesPlace.Core.Enums;
using BeautyCoursesPlace.Core.Models.Course;
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

        Task<IEnumerable<CourseCategoryServiceModel>>AllCategoryAsync();

        Task<bool> CategoryCreatedAsync(int categoryId);

        Task<int> MakeOnAsync(CourseFormModel model, int lectorId);

        Task<CourseQueryServiceModel> AllAsync(string? category = null,
                                          string ? searchTime = null,
                                          CourseSorting sorting = CourseSorting.Newest,
                                          int currentPage = 1,
                                          int coursesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNameAsync();

        Task<IEnumerable<CourseServiceModel>> AllCoursesByLectorIdAsync(int lectorId);

        Task<IEnumerable<CourseServiceModel>>AllCoursesByUserId(string userId);


        Task<bool>ExistAsync(int id);

        Task<CourseDetailServiceModel> CourseDetailsbyIdAsync(int id);
    }
}
