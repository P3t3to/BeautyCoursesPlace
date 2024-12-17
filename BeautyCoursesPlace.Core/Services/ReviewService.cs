using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Review;
using BeautyCoursesPlace.Infrastructure.Data.Common;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;

        public ReviewService(IRepository repository)
        {
            this.repository = repository;
        }


        public async Task AddReviewAsync(AddReviewViewModel model, string userId)
        {
            var review = new Review
            {
                CourseId = model.CourseId,
                UserId = userId,
                Feedback = model.Feedback,
                CreatedOn = DateTime.UtcNow
            };

            await repository.AddAsync(review);
            await repository.SaveChangesAsync();
        }

       
        public async Task<IEnumerable<ReviewViewModel>> GetReviewsByCourseIdAsync(int courseId)
        {
            return await repository.All<Review>()
                .Where(r => r.CourseId == courseId)
                .Select(r => new ReviewViewModel
                {
                    Feedback = r.Feedback,
                    CreatedOn = r.CreatedOn,
                    UserName = r.User.UserName 
                })
                .ToListAsync();
        }

        
    }
}

