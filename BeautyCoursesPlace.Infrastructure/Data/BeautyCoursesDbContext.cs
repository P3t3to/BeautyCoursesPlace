using BeautyCoursesPlace.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautyCoursesPlace.Infrastructure.Data
{
    public class BeautyCoursesDbContext : IdentityDbContext
    {
        public BeautyCoursesDbContext(DbContextOptions<BeautyCoursesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;


        public DbSet<Lector> Lectors { get; set; } = null!;
    }
}
