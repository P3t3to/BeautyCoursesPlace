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
    public class Partner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PartnerNameMaxLength)]
        [Comment("Partner name")]
        public string  Name { get; set; } = string.Empty;


       
        [MaxLength(AddressMaxLength)]
        [Comment("Partner address")]
        public string? Address{ get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();

        public List<Saloon> Saloons { get; set; } = new List<Saloon>();


        [Required]
        [Comment("Partner logo or image URL")]
        public string ImageUrl { get; set; } = string.Empty;


        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
