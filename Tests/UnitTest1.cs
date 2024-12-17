using BeautyCoursesPlace.Controllers;
using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Core.Models.Review;
using BeautyCoursesPlace.Core.Models.Saloon;
using BeautyCoursesPlace.Core.Services;
using BeautyCoursesPlace.Infrastructure.Data;
using BeautyCoursesPlace.Infrastructure.Data.Common;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Security.Claims;

namespace Tests
{
    public class Tests
    {

        private DbContextOptions<BeautyCoursesDbContext> dbContextOptions;

        private BeautyCoursesDbContext context;

        private Repository repository;

        private CourseController controller;

        private CourseService courseService;

        private LectorService lectorService;

        private ILogger<CourseController> logger;



        [SetUp]

        public void SetUp()

        {

            // Configure the in-memory database

            dbContextOptions = new DbContextOptionsBuilder<BeautyCoursesDbContext>()

                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())

                .Options;


            context = new BeautyCoursesDbContext(dbContextOptions);

            repository = new Repository(context);

            courseService = new CourseService(repository);

            lectorService = new LectorService(repository);

            logger = NullLogger<CourseController>.Instance; // ?????????? NullLogger ?? ?????????


            controller = new CourseController(courseService, lectorService, logger);


            var claims = new List<Claim>

        {

            new Claim(ClaimTypes.NameIdentifier, "user1"), // ??????? ID ?? ???????????

            // ???????? ????? ????? claims, ??? ? ??????????

        };


            var identity = new ClaimsIdentity(claims, "TestAuthType");

            var principal = new ClaimsPrincipal(identity);

            controller.ControllerContext = new ControllerContext

            {

                HttpContext = new DefaultHttpContext { User = principal }

            };

        }


        private void SeedDatabase()

        {
            context.Lectors.AddRange(new List<Lector>

            {

                new Lector { Id = 1, UserId = "user1", Telephone = "123456789" },

                new Lector { Id = 2, UserId = "user2", Telephone = "987654321" }

            });


            context.Categories.AddRange(new List<Category>

            {

                new Category { Id = 1, Name = "Category 1" },

                new Category { Id = 2, Name = "Category 2" }

            });


            context.Courses.AddRange(new List<Course>

            {

                new Course { Id = 1, Title = "Course 1", LectorId = 1, CategoryId = 1, StudentId = null },

                new Course { Id = 2, Title = "Course 2", LectorId = 1, CategoryId = 2, StudentId = "user1" },

                new Course { Id = 3, Title = "Course 3", LectorId = 2, CategoryId = 1, StudentId = null }

            });


            context.SaveChanges();

        }

        [TearDown]

        public void TearDown()

        {
            if (context is IDisposable disposableContext)

            {

                disposableContext.Dispose();

            }
            // ????????????? ?? ?????????, ??? ? ??????????

            if (controller is IDisposable disposableController)

            {

                disposableController.Dispose();

            }


            if (courseService is IDisposable disposableCourseService)

            {

                disposableCourseService.Dispose();

            }


            if (lectorService is IDisposable disposableLectorService)

            {

                disposableLectorService.Dispose();

            }
        }




        //[Test]

        //public async Task AllCategoriesNameAsync_ReturnsDistinctCategoryNames()

        //{

        //    // Act

        //    var result = await courseService.AllCategoriesNameAsync();


        //    // Assert

        //    Assert.AreEqual(2, result.Count());

        //    Assert.Contains("Category 1", result.ToList());

        //    Assert.Contains("Category 2", result.ToList());

        //}


        //[Test]

        //public async Task AllCategoryAsync_ReturnsAllCategories()

        //{

        //    // Act

        //    var result = await courseService.AllCategoryAsync();


        //    // Assert

        //    Assert.AreEqual(2, result.Count());

        //    Assert.IsTrue(result.Any(c => c.Id == 1 && c.Name == "Category 1"));

        //    Assert.IsTrue(result.Any(c => c.Id == 2 && c.Name == "Category 2"));

        //}


        //[Test]

        //public async Task AllCoursesByLectorIdAsync_ReturnsCoursesForGivenLectorId()

        //{

        //    // Act

        //    var result = await courseService.AllCoursesByLectorIdAsync(1);


        //    // Assert

        //    Assert.AreEqual(2, result.Count());

        //    Assert.IsTrue(result.Any(c => c.Title == "Course 1"));

        //    Assert.IsTrue(result.Any(c => c.Title == "Course 2"));

        //}


        ////[Test]

        ////public async Task AllCoursesByUser Id_ReturnsCoursesForGivenUser Id()

        ////{

        ////    // Act

        ////    var result = await courseService.AllCoursesByUser Id("user1");


        ////    // Assert

        ////    Assert.AreEqual(1, result.Count());

        ////    Assert.IsTrue(result.Any(c => c.Title == "Course 2"));

        ////}


        //[Test]

        //public async Task CategoryCreatedAsync_ReturnsTrue_WhenCategoryExists()

        //{

        //    // Act

        //    var result = await courseService.CategoryCreatedAsync(1);


        //    // Assert

        //    Assert.IsTrue(result);

        //}


        //[Test]

        //public async Task CategoryCreatedAsync_ReturnsFalse_WhenCategoryDoesNotExist()

        //{

        //    // Act

        //    var result = await courseService.CategoryCreatedAsync(3);


        //    // Assert

        //    Assert.IsFalse(result);

        //}


        ////[Test]

        ////public async Task CourseDetailsbyIdAsync_ReturnsCourseDetails()

        ////{

        ////    // Act

        ////    var result = await courseService.CourseDetailsbyIdAsync(1);


        ////    // Assert

        ////    Assert.IsNotNull(result);

        ////    Assert.AreEqual("Course 1", result.Title);

        ////}


        //[Test]

        //public async Task DeleteAsync_RemovesCourse()

        //{

        //    // Act

        //    await courseService.DeleteAsync(1);


        //    // Assert

        //    var courseExists = await courseService.ExistAsync(1);

        //    Assert.IsFalse(courseExists, "The course should have been deleted.");
        //}

        //[Test]

        //public async Task ClientPhoneNumberExistAsync_ReturnsTrue_WhenPhoneNumberExists()

        //{

        //    // Act

        //    var result = await lectorService.ClientPhoneNumberExistAsync("123456789");


        //    // Assert

        //    Assert.IsTrue(result);

        //}


        //[Test]

        //public async Task ClientPhoneNumberExistAsync_ReturnsFalse_WhenPhoneNumberDoesNotExist()

        //{

        //    // Act

        //    var result = await lectorService.ClientPhoneNumberExistAsync("000000000");


        //    // Assert

        //    Assert.IsFalse(result);

        //}




        ////public async Task ClientSignInAsync_ReturnsTrue_WhenUser_IsSignedIn()

        ////{

        ////    // Act

        ////    var result = await lectorService.ClientSignInAsync("user1");


        ////    // Assert

        ////    Assert.IsTrue(result);

        ////}

        ////[Test]

        ////public async Task ClientSignInAsync_ReturnsFalse_WhenUser IsNotSignedIn()

        ////{

        ////    // Act

        ////    var result = await lectorService.ClientSignInAsync("user3"); // user3 �� ����������


        ////    // Assert

        ////    Assert.IsFalse(result);

        ////}


        //[Test]

        //public async Task ExistByIdAsync_ReturnsTrue_WhenLectorExists()

        //{

        //    // Act

        //    var result = await lectorService.ExistByIdAsync("user1");


        //    // Assert

        //    Assert.IsTrue(result);

        //}


        //[Test]

        //public async Task ExistByIdAsync_ReturnsFalse_WhenLectorDoesNotExist()

        //{

        //    // Act

        //    var result = await lectorService.ExistByIdAsync("user3"); // user3 �� ����������


        //    // Assert

        //    Assert.IsFalse(result);

        //}






        ////public async Task GiveLectorIdAsync_ReturnsLectorId_WhenUser_Exists()

        ////{

        ////    // Arrange

        ////    await context.Users.AddAsync(new User { Id = 1, Username = "user1" });

        ////    await context.SaveChangesAsync();


        ////    // Act

        ////    var result = await lectorService.GiveLectorIdAsync("user1");


        ////    // Assert

        ////    Assert.AreEqual(1, result);

        ////}


        //[Test]

        //public async Task GiveLectorIdAsync_ReturnsNull_WhenUser_DoesNotExist()

        //{
        //}

        //[Test]

        //public async Task All_ReturnsViewResult_WithAllCourses()

        //{

        //    // Arrange

        //    var model = new AllCoursesQueryModel();


        //    // Act

        //    var result = await controller.All(model) as ViewResult;


        //    // Assert

        //    Assert.IsNotNull(result);

        //    Assert.IsInstanceOf<AllCoursesQueryModel>(result.Model);

        //}


        //[Test]

        //public async Task MyCourses_ReturnsViewResult_WithUser_Courses()

        //{

        //    // Arrange

        //    var userId = "user1"; // ��� ������ �� �������� ������ ������������� ID


        //    // Act

        //    var result = await controller.MyCourses() as ViewResult;


        //    // Assert

        //    Assert.IsNotNull(result);

        //    Assert.IsInstanceOf<IEnumerable<CourseServiceModel>>(result.Model);

        //}


        //[Test]

        //public async Task Details_ReturnsBadRequest_WhenCourseDoesNotExist()

        //{

        //    // Arrange

        //    int courseId = 1; // ��� ������� ID �� ����, ����� �� ����������

        //    string information = "info";


        //    // Act

        //    var result = await controller.Details(courseId, information);


        //    // Assert

        //    Assert.IsInstanceOf<BadRequestResult>(result);

        //}


        //[Test]

        //public async Task Add_ReturnsViewResult_WithCourseFormModel()

        //{

        //    // Act

        //    var result = await controller.Add() as ViewResult;


        //    // Assert

        //    Assert.IsNotNull(result);

        //    Assert.IsInstanceOf<CourseFormModel>(result.Model);

        //}


        //[Test]

        //public async Task Edit_ReturnsBadRequest_WhenCourseDoesNotExist()

        //{

        //    // Arrange

        //    int courseId = 1; // ��� ������� ID �� ����, ����� �� ����������


        //    // Act

        //    var result = await controller.Edit(courseId);


        //    // Assert

        //    Assert.IsInstanceOf<BadRequestResult>(result);

        //}




        //[Test]

        //public async Task Delete_ReturnsBadRequest_WhenCourseDoesNotExist()

        //{

        //    // Arrange

        //    int courseId = 999; // ���������� ID


        //    // Act

        //    var result = await controller.Delete(courseId);


        //    // Assert

        //    Assert.IsInstanceOf<BadRequestObjectResult>(result);

        //    var badRequestResult = result as BadRequestObjectResult;

        //    Assert.AreEqual("Course does not exist.", badRequestResult.Value);

        //}


        //[Test]

        ////public async Task Delete_ReturnsNotFound_WhenCourseDetailsCannotBeLoaded2()

        ////{

        ////    // Arrange

        ////    int courseId = 1; // ����������� ����

        ////    // �������� ���� � ���������

        ////    context.Courses.Add(new Course { Id = courseId, Address = "123 Main St", ImageUrl = "image.jpg", Title = "Test Course" });

        ////    context.SaveChanges();


        ////    // ����������� ������ �� ����� null

        ////    courseService = new CourseService(context);

        ////    controller = new CourseController(courseService);



        ////    // ���������� ��, �� ������������ ��� �����

        ////    controller.ControllerContext.HttpContext = new DefaultHttpContext();

        ////    controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

        ////    {

        ////new Claim(ClaimTypes.Name, "user1"),

        ////new Claim(ClaimTypes.Role, "Lector") // ������������ � ������

        ////    }));


        ////    // ��������� �����, �� �� ����������, �� �� ���� �� ���� �������

        ////    context.Courses.Remove(context.Courses.Find(courseId));

        ////    context.SaveChanges();


        ////    // Act

        ////    var result = await controller.Delete(courseId);


        ////    // Assert

        ////    Assert.IsInstanceOf<NotFoundObjectResult>(result);

        ////    var notFoundResult = result as NotFoundObjectResult;

        ////    Assert.AreEqual("Course details could not be loaded.", notFoundResult.Value);

        ////}




        //public async Task Delete_ReturnsView_WhenCourseExists()



        // Arrange

        //    int courseId = 1; // ����������� ����

        //var course = new Course { Id = courseId, Title = "Test Course", Address = "Test Address", ImageUrl = "test.jpg" };

        //context.Courses.Add(course);

        //    context.SaveChanges();


        //    // ��������� ����������� (��������, ������� User.Id() � User.IsAdmin())

        //    var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

        //    {

        //new Claim(ClaimTypes.NameIdentifier, "userId"), // �������� � ������ �������������

        //new Claim("IsAdmin", "true") // ��� "false", � ���������� �� �����

        //    }));


        //controller.ControllerContext = new ControllerContext()

        //{

        //    HttpContext = new DefaultHttpContext() { User = user }

        //    };


        //// Act

        //var result = await controller.Delete(courseId);


        //// Assert

        //Assert.IsInstanceOf<ViewResult>(result);

        //    var viewResult = result as ViewResult;

        //Assert.IsNotNull(viewResult);

        //    Assert.IsInstanceOf<CourseDetailsViewModel>(viewResult.Model);

        //}

        [Test]
    public async Task GetSaloonsByPartnerIdAsync_ReturnsCorrectSaloons()
    {
        var partnerId = 1;

        // ������� ��, �� ������ in-memory DbContext � ��������������
        var saloons = new List<Saloon>
    {
        new Saloon { Id = 1, Name = "Saloon 1", Address = "Address 1", PartnerId = partnerId },
        new Saloon { Id = 2, Name = "Saloon 2", Address = "Address 2", PartnerId = partnerId }
    };

        // ������ �� in-memory DbContext
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
                        .UseInMemoryDatabase(databaseName: "BeautyCoursesDb")
                        .Options;

        using (var context = new BeautyCoursesDbContext(options))
        {
            await context.Saloons.AddRangeAsync(saloons);
            await context.SaveChangesAsync();

            // ��������� �� IRepository
            var repository = new Repository(context); // ��� IRepository � ���������� �� �������������

            // Act
            var service = new SaloonService(repository); // ��������, ����� ����������
            var result = await service.GetSaloonsByPartnerIdAsync(partnerId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Any(r => r.Name == "Saloon 1"));
            Assert.IsTrue(result.Any(r => r.Name == "Saloon 2"));
        }
    }

    [Test]
    public async Task GetSaloonsByPartnerIdAsync_ReturnsEmptyList_WhenNoSaloonsFound()
    {
        /// Arrange
        var partnerId = 999; // �� ����������� ��������

        // ������ �� in-memory DbContext
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
                        .UseInMemoryDatabase(databaseName: "BeautyCoursesDb")
                        .Options;

        using (var context = new BeautyCoursesDbContext(options))
        {
            // ���� �� �������� ������ �� ���� ��������
            await context.SaveChangesAsync();

            // ��������� �� IRepository
            var repository = new Repository(context);

            // Act
            var service = new SaloonService(repository); // ��������, ����� ����������
            var result = await service.GetSaloonsByPartnerIdAsync(partnerId);

            // Assert
            Assert.NotNull(result); // ������� ��, �� ���������� �� � null
            Assert.AreEqual(0, result.Count); // ���������� ������ �� � ������ ������
        }
    }

    [Test]
    public async Task UserHasSaloonAsync_ReturnsTrue_WhenUserHasSaloon()
    {
        // Arrange
        var userId = "user123"; // ������������� �������������, �� ����� ��� �����
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
                        .UseInMemoryDatabase(databaseName: "BeautyCoursesDb")
                        .Options;

        using (var context = new BeautyCoursesDbContext(options))
        {
            // �������� �� ����� �� ����������� � id "user123"
            context.Saloons.Add(new Saloon { Id = 1, Name = "Salon A", Address = "Address A", UserId = userId });
            await context.SaveChangesAsync();

            // ��������� �� IRepository
            var repository = new Repository(context);

            // Act
            var service = new SaloonService(repository); // ��������, ����� ����������
            var result = await service.UserHasSaloonAsync(userId);

            // Assert
            Assert.IsTrue(result); // ����������� ���� ������������ ��� �����
        }
    }

    [Test]
    public async Task UserHasSaloonAsync_ReturnsFalse_WhenUserHasNoSaloon()
    {
        // Arrange
        var userId = "user999"; // ������������� �������������, �� ����� ���� �����
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
                        .UseInMemoryDatabase(databaseName: "BeautyCoursesDb")
                        .Options;

        using (var context = new BeautyCoursesDbContext(options))
        {
            // ���� �� �������� ������ �� ���� ����������
            await context.SaveChangesAsync();

            // ��������� �� IRepository
            var repository = new Repository(context);

            // Act
            var service = new SaloonService(repository); // ��������, ����� ����������
            var result = await service.UserHasSaloonAsync(userId);

            // Assert
            Assert.IsFalse(result); // ����������� ���� ������������ ���� �����
        }
    }

    [Test]
    public async Task CreateSaloonAsync_CreatesSaloonAndPartner_WhenValidData()
    {
        // Arrange
        var userId = "user123";  // ������������� �������������
        var model = new SaloonViewModel
        {
            Name = "Salon A",
            Address = "123 Street"
        };

        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
                        .UseInMemoryDatabase(databaseName: "BeautyCoursesDb")
                        .Options;

        using (var context = new BeautyCoursesDbContext(options))
        {
            // ��������� �� IRepository � ���������
            var repository = new Repository(context);

            // ��������� �� ��������, ����� ����������
            var service = new SaloonService(repository);

            // Act
            var saloonId = await service.CreateSaloonAsync(model, userId);

            // Assert
            var saloon = await context.Saloons.FindAsync(saloonId);
            var partner = await context.Partners.FirstOrDefaultAsync(p => p.UserId == userId);

            // ����������� ���� ������� � �������� � ��� ��������� PartnerId
            Assert.IsNotNull(saloon);
            Assert.AreEqual(model.Name, saloon.Name);
            Assert.AreEqual(model.Address, saloon.Address);
            Assert.AreEqual(partner.Id, saloon.PartnerId);

            // ����������� ���� ���������� � �������� � ��� ��������� userId
            Assert.IsNotNull(partner);
            Assert.AreEqual(userId, partner.UserId);
        }
    }

    [Test]
    public async Task CreateSaloonAsync_ReturnsNewSaloonId_WhenSaloonIsCreated()
    {
        // Arrange
        var userId = "user123";  // ������������� �������������
        var model = new SaloonViewModel
        {
            Name = "Salon B",
            Address = "456 Avenue"
        };

        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
                        .UseInMemoryDatabase(databaseName: "BeautyCoursesDb")
                        .Options;

        using (var context = new BeautyCoursesDbContext(options))
        {
            // ��������� �� IRepository � ���������
            var repository = new Repository(context);

            // ��������� �� ��������, ����� ����������
            var service = new SaloonService(repository);

            // Act
            var saloonId = await service.CreateSaloonAsync(model, userId);

            // Assert
            // ����������� ���� ������� � �������� � ����� ID �� �������������� �����
            Assert.AreNotEqual(0, saloonId);  // �����������, �� ��������� �� id � �������� �� 0
        }

    }

    [Test]
    public async Task GetSaloonByIdAsync_ReturnsSaloon_WhenSaloonExists()
    {
        // Arrange
        var saloonId = 1;
        var model = new Saloon
        {
            Id = saloonId,
            Name = "Salon A",
            Address = "123 Street"
        };

        // ��������� in-memory ���� ����� � �������� ������
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesDb")
            .Options;

        using (var context = new BeautyCoursesDbContext(options))
        {
            context.Saloons.Add(model);
            await context.SaveChangesAsync();
        }

        // ��������� ������ �� ��������
        using (var context = new BeautyCoursesDbContext(options))
        {
            var repository = new Repository(context);
            var service = new SaloonService(repository);

            // Act
            var result = await service.GetSaloonByIdAsync(saloonId);

            // Assert
            Assert.IsNotNull(result);  // �������� ���������� �� �� � null
            Assert.AreEqual(saloonId, result.Id);  // ����������� ���� ID-�� �������
            Assert.AreEqual("Salon A", result.Name);  // ����������� ����� �� ������
        }
    }

    [Test]
    public async Task GetSaloonByIdAsync_ReturnsNull_WhenSaloonDoesNotExist()
    {
        // Arrange
        var saloonId = 999;  // �� ����������� ID

        // ��������� in-memory ���� ����� (��� ������)
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesDb")
            .Options;

        // ��������� ������ �� ��������
        using (var context = new BeautyCoursesDbContext(options))
        {
            var repository = new Repository(context);
            var service = new SaloonService(repository);

            // Act
            var result = await service.GetSaloonByIdAsync(saloonId);

            // Assert
            Assert.IsNull(result);  // �������� ���������� �� � null
        }
    }

    [Test]
    public async Task AddReviewAsync_AddsReviewToDatabase()
    {
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var reviewService = new ReviewService(new Repository(context));

        var userId = "user123";
        var courseId = 1;
        var model = new AddReviewViewModel
        {
            CourseId = courseId,
            Feedback = "Great course!"
        };

        await reviewService.AddReviewAsync(model, userId);

        var review = await context.Reviews
            .FirstOrDefaultAsync(r => r.UserId == userId && r.CourseId == courseId);

        Assert.IsNotNull(review);
        Assert.AreEqual(model.Feedback, review.Feedback);
        Assert.AreEqual(userId, review.UserId);
        Assert.AreEqual(courseId, review.CourseId);
        Assert.AreEqual(DateTime.UtcNow.Date, review.CreatedOn.Date);
    }

    [Test]
    public async Task AddReviewAsync_DoesNotAddReview_WhenFeedbackIsEmpty()
    {
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var reviewService = new ReviewService(new Repository(context));

        var userId = "user123";
        var courseId = 1;
        var model = new AddReviewViewModel
        {
            CourseId = courseId,
            Feedback = ""
        };

        await reviewService.AddReviewAsync(model, userId);

        var review = await context.Reviews
            .FirstOrDefaultAsync(r => r.UserId == userId && r.CourseId == courseId);

        // Expecting no review to be added
        Assert.IsNull(review);
    }

        

  

    [Test]
    public async Task AddReviewAsync_ThrowsException_WhenSavingFails()
    {
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var reviewService = new ReviewService(new Repository(context));

        var userId = "user123";
        var courseId = 1;
        var model = new AddReviewViewModel
        {
            CourseId = courseId,
            Feedback = "Great course!"
        };

        // Simulating database failure by changing state to cause exception
        context.Add(new Review
        {
            CourseId = courseId,
            UserId = userId,
            Feedback = "Test",
            CreatedOn = DateTime.UtcNow
        });

        await context.SaveChangesAsync();

        context.Add(new Review
        {
            CourseId = courseId,
            UserId = userId,
            Feedback = "New review",
            CreatedOn = DateTime.UtcNow
        });

        // Simulate failure on second save
        try
        {
            await reviewService.AddReviewAsync(model, userId);
            Assert.Fail("Expected exception due to DB save failure.");
        }
        catch (Exception)
        {
            // Expected exception
        }
    }

    [Test]
    public async Task GetReviewsByCourseIdAsync_ReturnsCorrectReviews_WhenReviewsExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var reviewService = new ReviewService(new Repository(context));

        var courseId = 1;
        var userId = "user123";

        // �������� ���� � ������
        var user = new ApplicationUser { UserName = "User1" };
        context.Users.Add(user);
        context.SaveChanges();

        var review1 = new Review
        {
            CourseId = courseId,
            UserId = userId,
            Feedback = "Great course!",
            CreatedOn = DateTime.UtcNow,
            User = user
        };

        var review2 = new Review
        {
            CourseId = courseId,
            UserId = userId,
            Feedback = "Very helpful!",
            CreatedOn = DateTime.UtcNow,
            User = user
        };

        context.Reviews.Add(review1);
        context.Reviews.Add(review2);
        context.SaveChanges();

        // Act
        var result = await reviewService.GetReviewsByCourseIdAsync(courseId);

        // Assert
        Assert.AreEqual(2, result.Count());
        Assert.AreEqual("Great course!", result.First().Feedback);
        Assert.AreEqual("Very helpful!", result.Last().Feedback);
    }

    [Test]
    public async Task GetReviewsByCourseIdAsync_ReturnsEmptyList_WhenNoReviewsExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var reviewService = new ReviewService(new Repository(context));

        var courseId = 1;

        // Act
        var result = await reviewService.GetReviewsByCourseIdAsync(courseId);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public async Task GetReviewsByCourseIdAsync_ReturnsEmptyList_WhenNoUsersExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var reviewService = new ReviewService(new Repository(context));

        var courseId = 1;

        // �������� ������, �� ��� �������� �����������
        var review1 = new Review
        {
            CourseId = courseId,
            UserId = "invalidUser",
            Feedback = "Great course!",
            CreatedOn = DateTime.UtcNow,
            User = null // ���� ������� ����������
        };

        context.Reviews.Add(review1);
        context.SaveChanges();

        // Act
        var result = await reviewService.GetReviewsByCourseIdAsync(courseId);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public async Task GetPartnerByIdAsync_ReturnsCorrectPartner_WhenPartnerExists()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var partnerService = new PartnerService(new Repository(context));

        var partnerId = 1;
        var partner = new Partner
        {
            Id = partnerId,
            Name = "Partner1",
            Saloons = new List<Saloon>
            {
                new Saloon { Id = 1, Name = "Saloon 1", Address = "Address 1" }
            },
            Courses = new List<Course>
            {
                new Course { Id = 1, Title = "Course 1", Description = "Description 1" }
            }
        };

        context.Partners.Add(partner);
        context.SaveChanges();

        // Act
        var result = await partnerService.GetPartnerByIdAsync(partnerId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(partnerId, result.Id);
        Assert.AreEqual("Partner1", result.Name);
        Assert.AreEqual(1, result.Saloons.Count); // ����������� ���� ��� ������
        Assert.AreEqual(1, result.Courses.Count); // ����������� ���� ��� �������
    }

    [Test]
    public async Task GetPartnerByIdAsync_ReturnsNull_WhenPartnerDoesNotExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var partnerService = new PartnerService(new Repository(context));

        var partnerId = 999; // ID, ����� �� ����������

        // Act
        var result = await partnerService.GetPartnerByIdAsync(partnerId);

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public async Task GetPartnerByIdAsync_ReturnsPartnerWithEmptyLists_WhenPartnerHasNoCoursesOrSaloons()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var partnerService = new PartnerService(new Repository(context));

        var partnerId = 2;
        var partner = new Partner
        {
            Id = partnerId,
            Name = "Partner2",
            Saloons = new List<Saloon>(), // ��� ������
            Courses = new List<Course>() // ��� �������
        };

        context.Partners.Add(partner);
        context.SaveChanges();

        // Act
        var result = await partnerService.GetPartnerByIdAsync(partnerId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(partnerId, result.Id);
        Assert.AreEqual("Partner2", result.Name);
        Assert.IsEmpty(result.Saloons); // ����������� ���� �������� �� ������
        Assert.IsEmpty(result.Courses); // ����������� ���� ��������� �� ������
    }

    [Test]
    public async Task GetAllPartnersAsync_ReturnsAllPartners_WhenPartnersExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var partnerService = new PartnerService(new Repository(context));

        // �������� ������� ��������� � ������
        var partner1 = new Partner { Id = 1, Name = "Partner 1" };
        var partner2 = new Partner { Id = 2, Name = "Partner 2" };

        context.Partners.Add(partner1);
        context.Partners.Add(partner2);
        context.SaveChanges();

        // Act
        var result = await partnerService.GetAllPartnersAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count());  // �������� 2 ���������
        Assert.Contains(partner1, result.ToList());  // ����������� ���� ������� �������� � � ���������
        Assert.Contains(partner2, result.ToList());  // ����������� ���� ������� �������� � � ���������
    }

    [Test]
    public async Task GetAllPartnersAsync_ReturnsEmptyList_WhenNoPartnersExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
            .UseInMemoryDatabase("BeautyCoursesTestDb")
            .Options;

        var context = new BeautyCoursesDbContext(options);
        var partnerService = new PartnerService(new Repository(context));

        // ���� �� �������� ���������, ���� �� ������ � ������.

        // Act
        var result = await partnerService.GetAllPartnersAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);  // �������� ������ ������
    }
}
}






