using BeautyCoursesPlace.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Infrastructure.Data.SeedDb
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
               .HasOne(c => c.Category)
               .WithMany(c => c.Courses)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(c => c.Lector)
            .WithMany(c => c.Courses)
            .HasForeignKey(c => c.LectorId)
            .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Course[] {data.FisrtCourse, data.SecondCourse,data.ThirdCourse});    
        }
    }
}
