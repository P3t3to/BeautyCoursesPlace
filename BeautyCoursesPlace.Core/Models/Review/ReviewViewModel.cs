using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyCoursesPlace.Core.Models;



namespace BeautyCoursesPlace.Core.Models.Review
{
    public class ReviewViewModel
    {
        public string Feedback { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; } = null!;
    }
}
