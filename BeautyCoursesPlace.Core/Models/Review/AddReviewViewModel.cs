using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Review
{
    public class AddReviewViewModel
    {

        [Required]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Feedback { get; set; } = null!;
    }
}
