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
                ImageUrl = "https://www.pinterest.com/pin/hair-makeup-nails--258957047313127874/",
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
                ImageUrl = "https://www.shutterstock.com/image-photo/stylist-using-hair-brush-dryer-bright-2442221183",
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
                ImageUrl = "https://www.gettyimages.com/detail/photo/young-woman-painting-fingernails-close-up-royalty-free-image/DA20814?adppopup=true",
                Cost = 2000.00M,
                CategoryId = NailsCategory.Id,
                LectorId = Lector.Id
            };


        }
    }
}
