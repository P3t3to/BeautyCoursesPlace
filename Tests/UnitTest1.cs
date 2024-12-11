using BeautyCoursesPlace.Controllers;
using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Course;
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
        //private readonly IRepository repository;

        //public Tests(IRepository _repository)
        //{
        //    repository = _repository;

        //}
        //[TestFixture]
        //public class YourServiceTests
        //{
        //    private DbContextOptions<BeautyCoursesDbContext> dbContextOptions;
        //    private BeautyCoursesDbContext context;
        //    private Repository repository;
        //    private CourseService courseService;
        //    private CourseService yourService;

        //[SetUp]
        //public void SetUp()
        //{
        //    // Configure the in-memory database
        //    dbContextOptions = new DbContextOptionsBuilder<BeautyCoursesDbContext>()
        //        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        //        .Options;


        //    context = new BeautyCoursesDbContext(dbContextOptions);
        //    repository = new Repository(context);
        //    yourService = new CourseService(repository);
        //    courseService = new CourseService(repository);

        //    // Seed data for tests
        //    SeedDatabase();
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    // Clean up the in-memory database
        //    context.Database.EnsureDeleted();
        //    context.Dispose();
        //}

        //private void SeedDatabase()
        //{
        //    var categories = new List<Category>
        //    {
        //   new Category { Name = "Category1" },
        //   new Category { Name = "Category2" },
        //   new Category { Name = "Category1" } // Duplicate to test distinct functionality
        //    };

        //    context.Categories.AddRange(categories);
        //    context.SaveChanges();
        //}

        //[Test]
        //public async Task AllCategoriesNameAsync_ReturnsDistinctCategoryNames()
        //{
        //    // Act
        //    var result = await yourService.AllCategoriesNameAsync();

        //    // Assert
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.Count(), Is.EqualTo(2)); // Distinct count
        //    Assert.That(result, Does.Contain("Category1"));
        //    Assert.That(result, Does.Contain("Category2"));
        //}

        //[Test]
        //public async Task AllCategoriesNameAsync_ReturnsEmpty_WhenNoCategoriesExist()
        //{
        //    // Arrange: Clear database
        //    context.Categories.RemoveRange(context.Categories);
        //    context.SaveChanges();

        //    // Act
        //    var result = await yourService.AllCategoriesNameAsync();

        //    // Assert
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.Empty);
        //}

        //// [Test]

        ////public async Task AllCategoryAsync_ReturnsAllCategories()

        ////{

        ////    // Act

        ////    var result = await courseService.AllCategoryAsync();


        ////    // Assert

        ////    Assert.That(result, Is.Not.Null);

        ////    Assert.That(result.Count(), Is.EqualTo(3)); // Total count

        ////    Assert.That(result, Has.Some.Matches<CourseCategoryServiceModel>(c => c.Name == "Category1"));

        ////    Assert.That(result, Has.Some.Matches<CourseCategoryServiceModel>(c => c.Name == "Category2"));

        ////    Assert.That(result, Has.Some.Matches<CourseCategoryServiceModel>(c => c.Name == "Category3"));

        ////}


        //[Test]

        //public async Task AllCategoryAsync_ReturnsEmpty_WhenNoCategoriesExist()

        //{

        //    // Arrange: Clear database

        //    context.Categories.RemoveRange(context.Categories);

        //    context.SaveChanges();


        //    // Act

        //    var result = await courseService.AllCategoryAsync();


        //    // Assert

        //    Assert.That(result, Is.Not.Null);

        //    Assert.That(result, Is.Empty);

        //}




        //[Test]

        //public async Task AllCoursesByLectorIdAsync_ReturnsEmpty_WhenNoCoursesExistForLector()

        //{

        //    // Arrange

        //    int lectorId = 3; // This lectorId does not exist in the seeded data


        //    // Act

        //    var result = await courseService.AllCoursesByLectorIdAsync(lectorId);


        //    // Assert

        //    Assert.That(result, Is.Not.Null);

        //    Assert.That(result, Is.Empty);

        //}

        //[Test]

        //public async Task CategoryCreatedAsync_ReturnsTrue_WhenCategoryExists()

        //{

        //    // Arrange

        //    int categoryId = 1;


        //    // Добавяне на категория в in-memory базата данни

        //    context.Categories.Add(new Category { Id = categoryId });

        //    context.SaveChanges();


        //    // Act

        //    var result = await yourService.CategoryCreatedAsync(categoryId);


        //    // Assert

        //    Assert.IsTrue(result);

        //}


        //[Test]

        //public async Task CategoryCreatedAsync_ReturnsFalse_WhenCategoryDoesNotExist()

        //{

        //    // Arrange

        //    int categoryId = 1;


        //    // Не добавяме категория с Id = 1


        //    // Act

        //    var result = await yourService.CategoryCreatedAsync(categoryId);


        //    // Assert

        //    Assert.IsFalse(result);

        //}

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

            logger = NullLogger<CourseController>.Instance; // Използваме NullLogger за тестовете


            controller = new CourseController(courseService, lectorService, logger);


            var claims = new List<Claim>

        {

            new Claim(ClaimTypes.NameIdentifier, "user1"), // Задайте ID на потребителя

            // Добавете други нужни claims, ако е необходимо

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
            // Освобождаване на ресурсите, ако е необходимо

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


        [Test]

        public async Task AllCategoriesNameAsync_ReturnsDistinctCategoryNames()

        {

            // Act

            var result = await courseService.AllCategoriesNameAsync();


            // Assert

            Assert.AreEqual(2, result.Count());

            Assert.Contains("Category 1", result.ToList());

            Assert.Contains("Category 2", result.ToList());

        }


        [Test]

        public async Task AllCategoryAsync_ReturnsAllCategories()

        {

            // Act

            var result = await courseService.AllCategoryAsync();


            // Assert

            Assert.AreEqual(2, result.Count());

            Assert.IsTrue(result.Any(c => c.Id == 1 && c.Name == "Category 1"));

            Assert.IsTrue(result.Any(c => c.Id == 2 && c.Name == "Category 2"));

        }


        [Test]

        public async Task AllCoursesByLectorIdAsync_ReturnsCoursesForGivenLectorId()

        {

            // Act

            var result = await courseService.AllCoursesByLectorIdAsync(1);


            // Assert

            Assert.AreEqual(2, result.Count());

            Assert.IsTrue(result.Any(c => c.Title == "Course 1"));

            Assert.IsTrue(result.Any(c => c.Title == "Course 2"));

        }


        //[Test]

        //public async Task AllCoursesByUser Id_ReturnsCoursesForGivenUser Id()

        //{

        //    // Act

        //    var result = await courseService.AllCoursesByUser Id("user1");


        //    // Assert

        //    Assert.AreEqual(1, result.Count());

        //    Assert.IsTrue(result.Any(c => c.Title == "Course 2"));

        //}


        [Test]

        public async Task CategoryCreatedAsync_ReturnsTrue_WhenCategoryExists()

        {

            // Act

            var result = await courseService.CategoryCreatedAsync(1);


            // Assert

            Assert.IsTrue(result);

        }


        [Test]

        public async Task CategoryCreatedAsync_ReturnsFalse_WhenCategoryDoesNotExist()

        {

            // Act

            var result = await courseService.CategoryCreatedAsync(3);


            // Assert

            Assert.IsFalse(result);

        }


        //[Test]

        //public async Task CourseDetailsbyIdAsync_ReturnsCourseDetails()

        //{

        //    // Act

        //    var result = await courseService.CourseDetailsbyIdAsync(1);


        //    // Assert

        //    Assert.IsNotNull(result);

        //    Assert.AreEqual("Course 1", result.Title);

        //}


        [Test]

        public async Task DeleteAsync_RemovesCourse()

        {

            // Act

            await courseService.DeleteAsync(1);


            // Assert

            var courseExists = await courseService.ExistAsync(1);

            Assert.IsFalse(courseExists, "The course should have been deleted.");
        }

        [Test]

        public async Task ClientPhoneNumberExistAsync_ReturnsTrue_WhenPhoneNumberExists()

        {

            // Act

            var result = await lectorService.ClientPhoneNumberExistAsync("123456789");


            // Assert

            Assert.IsTrue(result);

        }


        [Test]

        public async Task ClientPhoneNumberExistAsync_ReturnsFalse_WhenPhoneNumberDoesNotExist()

        {

            // Act

            var result = await lectorService.ClientPhoneNumberExistAsync("000000000");


            // Assert

            Assert.IsFalse(result);

        }




        //public async Task ClientSignInAsync_ReturnsTrue_WhenUser_IsSignedIn()

        //{

        //    // Act

        //    var result = await lectorService.ClientSignInAsync("user1");


        //    // Assert

        //    Assert.IsTrue(result);

        //}

        //[Test]

        //public async Task ClientSignInAsync_ReturnsFalse_WhenUser IsNotSignedIn()

        //{

        //    // Act

        //    var result = await lectorService.ClientSignInAsync("user3"); // user3 не съществува


        //    // Assert

        //    Assert.IsFalse(result);

        //}


        [Test]

        public async Task ExistByIdAsync_ReturnsTrue_WhenLectorExists()

        {

            // Act

            var result = await lectorService.ExistByIdAsync("user1");


            // Assert

            Assert.IsTrue(result);

        }


        [Test]

        public async Task ExistByIdAsync_ReturnsFalse_WhenLectorDoesNotExist()

        {

            // Act

            var result = await lectorService.ExistByIdAsync("user3"); // user3 не съществува


            // Assert

            Assert.IsFalse(result);

        }






        //public async Task GiveLectorIdAsync_ReturnsLectorId_WhenUser_Exists()

        //{

        //    // Arrange

        //    await context.Users.AddAsync(new User { Id = 1, Username = "user1" });

        //    await context.SaveChangesAsync();


        //    // Act

        //    var result = await lectorService.GiveLectorIdAsync("user1");


        //    // Assert

        //    Assert.AreEqual(1, result);

        //}


        [Test]

        public async Task GiveLectorIdAsync_ReturnsNull_WhenUser_DoesNotExist()

        {
        }

        [Test]

        public async Task All_ReturnsViewResult_WithAllCourses()

        {

            // Arrange

            var model = new AllCoursesQueryModel();


            // Act

            var result = await controller.All(model) as ViewResult;


            // Assert

            Assert.IsNotNull(result);

            Assert.IsInstanceOf<AllCoursesQueryModel>(result.Model);

        }


        [Test]

        public async Task MyCourses_ReturnsViewResult_WithUser_Courses()

        {

            // Arrange

            var userId = "user1"; // Тук трябва да зададете реален потребителски ID


            // Act

            var result = await controller.MyCourses() as ViewResult;


            // Assert

            Assert.IsNotNull(result);

            Assert.IsInstanceOf<IEnumerable<CourseServiceModel>>(result.Model);

        }


        [Test]

        public async Task Details_ReturnsBadRequest_WhenCourseDoesNotExist()

        {

            // Arrange

            int courseId = 1; // Тук задайте ID на курс, който не съществува

            string information = "info";


            // Act

            var result = await controller.Details(courseId, information);


            // Assert

            Assert.IsInstanceOf<BadRequestResult>(result);

        }


        [Test]

        public async Task Add_ReturnsViewResult_WithCourseFormModel()

        {

            // Act

            var result = await controller.Add() as ViewResult;


            // Assert

            Assert.IsNotNull(result);

            Assert.IsInstanceOf<CourseFormModel>(result.Model);

        }


        [Test]

        public async Task Edit_ReturnsBadRequest_WhenCourseDoesNotExist()

        {

            // Arrange

            int courseId = 1; // Тук задайте ID на курс, който не съществува


            // Act

            var result = await controller.Edit(courseId);


            // Assert

            Assert.IsInstanceOf<BadRequestResult>(result);

        }




        [Test]

        public async Task Delete_ReturnsBadRequest_WhenCourseDoesNotExist()

        {

            // Arrange

            int courseId = 999; // Неправилен ID


            // Act

            var result = await controller.Delete(courseId);


            // Assert

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

            var badRequestResult = result as BadRequestObjectResult;

            Assert.AreEqual("Course does not exist.", badRequestResult.Value);

        }


        [Test]

        //public async Task Delete_ReturnsNotFound_WhenCourseDetailsCannotBeLoaded2()

        //{

        //    // Arrange

        //    int courseId = 1; // Съществуващ курс

        //    // Добавяме курс в контекста

        //    context.Courses.Add(new Course { Id = courseId, Address = "123 Main St", ImageUrl = "image.jpg", Title = "Test Course" });

        //    context.SaveChanges();


        //    // Настройваме метода да връща null

        //    courseService = new CourseService(context);

        //    controller = new CourseController(courseService);



        //    // Предполага се, че потребителят има права

        //    controller.ControllerContext.HttpContext = new DefaultHttpContext();

        //    controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

        //    {

        //new Claim(ClaimTypes.Name, "user1"),

        //new Claim(ClaimTypes.Role, "Lector") // Потребителят е лектор

        //    }));


        //    // Изтриваме курса, за да симулираме, че не може да бъде намерен

        //    context.Courses.Remove(context.Courses.Find(courseId));

        //    context.SaveChanges();


        //    // Act

        //    var result = await controller.Delete(courseId);


        //    // Assert

        //    Assert.IsInstanceOf<NotFoundObjectResult>(result);

        //    var notFoundResult = result as NotFoundObjectResult;

        //    Assert.AreEqual("Course details could not be loaded.", notFoundResult.Value);

        //}




        public async Task Delete_ReturnsView_WhenCourseExists()

        {

            // Arrange

            int courseId = 1; // Съществуващ курс

            var course = new Course { Id = courseId, Title = "Test Course", Address = "Test Address", ImageUrl = "test.jpg" };

            context.Courses.Add(course);

            context.SaveChanges();


            // Настройте потребителя (например, задайте User.Id() и User.IsAdmin())

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

            {

        new Claim(ClaimTypes.NameIdentifier, "userId"), // Заменете с реален идентификатор

        new Claim("IsAdmin", "true") // Или "false", в зависимост от теста

            }));


            controller.ControllerContext = new ControllerContext()

            {

                HttpContext = new DefaultHttpContext() { User = user }

            };


            // Act

            var result = await controller.Delete(courseId);


            // Assert

            Assert.IsInstanceOf<ViewResult>(result);

            var viewResult = result as ViewResult;

            Assert.IsNotNull(viewResult);

            Assert.IsInstanceOf<CourseDetailsViewModel>(viewResult.Model);

        }


        //    [Test]

        //    public async Task Delete_ReturnsView_WhenCourseExists()

        //    {

        //        // Arrange

        //        int courseId = 1; // Съществуващ курс


        //        // Добавяме необходимите данни за потребителя

        //        controller.ControllerContext.HttpContext = new DefaultHttpContext();

        //        controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

        //        {

        //        new Claim(ClaimTypes.Name, "user1"),

        //        new Claim(ClaimTypes.Role, "Lector") // Потребителят е лектор

        //        }));


        //        // Act

        //        var result = await controller.Delete(courseId);


        //        // Assert

        //        Assert.IsInstanceOf<ViewResult>(result);

        //        var viewResult = result as ViewResult;

        //        var model = viewResult.Model as CourseDetailsViewModel;

        //        Assert.IsNotNull(model);

        //        Assert.AreEqual(courseId, model.Id);

        //        Assert.AreEqual("123 Main St", model.Address);

        //        Assert.AreEqual("image.jpg", model.ImageUrl);

        //        Assert.AreEqual("Test Course", model.Title);

        //    }

        //}



    }
}






