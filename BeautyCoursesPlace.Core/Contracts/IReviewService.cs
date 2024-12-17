using BeautyCoursesPlace.Core.Models.Review;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Contracts
{
    public interface IReviewService
    {
        Task AddReviewAsync(AddReviewViewModel model, string userId);
        Task<IEnumerable<ReviewViewModel>> GetReviewsByCourseIdAsync(int courseId);
    }

}
