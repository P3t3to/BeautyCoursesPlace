using BeautyCoursesPlace.Infrastructure.Data.Models;
using BeautyCoursesPlace.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautyCoursesPlace.Infrastructure.Data
{
    public class BeautyCoursesDbContext : IdentityDbContext<ApplicationUser>
    {
        public BeautyCoursesDbContext(DbContextOptions<BeautyCoursesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new LectorConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            

            base.OnModelCreating(builder);

            builder.Entity<Partner>().HasData(
            new Partner { Id = 1,Name = "BeautyPlace", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNttQsOgRhhhzmKi-gAW23cj2VgGcayhsnkA&s" },
            new Partner { Id = 2,  Name = "HairByMaster", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQa4puCFpPTXAjYJHIMCXEz1vUFuCj6LnwUKg&s" }
            );

        }

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;


        public DbSet<Lector> Lectors { get; set; } = null!;


        public DbSet<Partner> Partners { get; set; } = null!;

        public DbSet<Saloon> Saloons { get; set; } = null!;


    }
}
