using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeautyCoursesPlace.Infrastructure.Constants.DataConstants;

namespace BeautyCoursesPlace.Infrastructure.Data.Models
{
    [Comment("Lector")]
    public class Lector
    {
        [Key]
        [Comment("Lector Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TelephoneMaxLength)]
        [Comment("Lector phone number")]
        public string Telephone { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public List<Course> Courses { get; set; } = new List<Course>();




    }
}
