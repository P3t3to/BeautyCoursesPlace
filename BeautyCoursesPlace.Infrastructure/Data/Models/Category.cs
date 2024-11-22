using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeautyCoursesPlace.Infrastructure.Constants.DataConstants;

namespace BeautyCoursesPlace.Infrastructure.Data.Models
{
    [Comment("Course category")]
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
