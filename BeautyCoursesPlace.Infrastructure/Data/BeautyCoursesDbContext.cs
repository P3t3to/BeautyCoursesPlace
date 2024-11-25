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

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Course>()
                .HasOne(c =>c.Category)
                .WithMany(c=>c.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Course>()
            .HasOne(c=>c.Lector)
            .WithMany(c => c.Courses)
            .HasForeignKey(c => c.LectorId)
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;


        public DbSet<Lector> Lectors { get; set; } = null!;


        public DbSet<Partner> Partners { get; set; } = null!;

        public DbSet<Saloon> Saloons { get; set; } = null!;


    }
}
