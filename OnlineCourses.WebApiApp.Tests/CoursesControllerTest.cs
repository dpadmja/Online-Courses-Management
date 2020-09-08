using System.Linq;
using OnlineCourses.WebApiApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Moq;
using OnlineCourses.Services;

namespace OnlineCourses.WebApiApp.Tests
{
    [TestClass]
    public class CoursesControllerTest
    {
        [TestMethod]
        public async Task TestCoursesControlleReturnsCourses()
        {
            Mock<ICourseService> mockCourseService = new Mock<ICourseService>();
            CoursesController courseController = new CoursesController(mockCourseService.Object);
            var actualCourses = await courseController.GetCourses();
            Assert.AreEqual(0, actualCourses.Count());
        }
    }
}
