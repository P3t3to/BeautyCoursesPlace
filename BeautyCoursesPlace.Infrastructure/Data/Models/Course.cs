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
    [Comment("Courses to display")]
    public class Course
    {
        [Key]
        [Required]
        [Comment("Course Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Course title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("Course address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Course description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Course image")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Course cost")]
        [Column(TypeName ="decimal(18,2)")]
        //[Range(typeof(decimal), CoursesCostMinLength,CoursesCostMaxLength,ConvertValueInInvariantCulture =true)]
        public decimal Cost { get; set; }

        [Required]
        [Comment("Category Identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Lector Identifier")]
        public int LectorId { get; set; }

        [ForeignKey(nameof(LectorId))]  
        public Lector Lector { get; set; } = null!;

        [Comment("Identifier for student")]
        public string? StudentId { get; set; }


        [Comment("Identifier for partner")]
        public int PartnerId { get; set; }

        [ForeignKey(nameof(PartnerId))]
        public Partner Partner { get; set; } = null!;


    }
}
