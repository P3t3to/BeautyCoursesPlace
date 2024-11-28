using BeautyCoursesPlace.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUser LectorUser { get; set; }

        public IdentityUser GuestUser { get; set; }


        public Lector Lector { get; set; }

        public Category MakeupCategory { get; set; }

        public Category HairCategory { get; set; }

        public Category NailsCategory { get; set; }

        public Course FisrtCourse { get; set; }

        public Course SecondCourse { get; set; }

        public Course ThirdCourse { get; set; }



        public SeedData()
        {
            SeedUsers();
            SeedLector();
            SeedCategories();
            SeedCourses();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            LectorUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com",

            };


            LectorUser.PasswordHash =
                 hasher.HashPassword(LectorUser, "lector123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(LectorUser, "guest123");
        }

        private void SeedLector()
        {
            Lector = new Lector()
            {
                Id = 1,
                Telephone = "+359888888888",
                UserId = LectorUser.Id
            };
        }

        private void SeedCategories()
        {
            MakeupCategory = new Category()
            {
                Id = 1,
                Name = "Makeup"
            };

            HairCategory = new Category()
            {
                Id = 2,
                Name = "Hair"
            };

            NailsCategory = new Category()
            {
                Id = 3,
                Name = "Nails"
            };
        }

        private void SeedCourses()
        {
            FisrtCourse = new Course()
            {
                Id = 1,
                Title = "Cut crease tehnique",
                Address = "17 Lydford Rd London UK",
                Description = "If you want to learn how to do Half cut crease and create this makeup look, join the course.",
                ImageUrl = "https://artdeco.com/cdn/shop/files/Shop-the-Look-Schminktipp-Cut-Crease_V2-600x600_600x600.jpg?v=1684735658",
                Cost = 700.00M,
                CategoryId = MakeupCategory.Id,
                LectorId = Lector.Id,
                StudentId = GuestUser.Id
            };

            SecondCourse = new Course()
            {
                Id = 2,
                Title = "Hair Styling: Blow-Dry, Cut, and Colour Like a Pro",
                Address = "  77 Sidmouth Rd London, England",
                Description = "This course covers several methods for professionally blow-drying, curling, trimming, and colouring hair.",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSY16nniu9WfRnBZisa1BKW5ss9sHlx2blUeg&s",
                Cost = 400.00M,
                CategoryId = HairCategory.Id,
                LectorId = Lector.Id
            };

            ThirdCourse = new Course()
            {
                Id = 3,
                Title = "Nail Care and Treatment ",
                Address = "290 Willesden Lane London, England",
                Description = "Learn how to care for nails like a pro and perform treatments like manicures and pedicures in this free online course.",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSE0LHapGysMlndotyOkN0h4T4RynF7P_xJEA&s",
                Cost = 2000.00M,
                CategoryId = NailsCategory.Id,
                LectorId = Lector.Id
            };


        }
    }
}
