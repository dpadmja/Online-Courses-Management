using System.Collections.Generic;
using System.Linq;
using OnlineCourses.Repository.DBModels;
using Microsoft.EntityFrameworkCore;

namespace OnlineCourses.Repository
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> courses) : base(courses)
        {
            PopulateCourses();
        }

        public CoursesDbContext()
        {

        }
        public DbSet<Course> Courses { get; set; }

        private void PopulateCourses()
        {
            var course1 = new Course { CourseId = 1, CourseName = "Science", Rating = 0 };
            var course2 = new Course { CourseId = 2, CourseName = "Maths", Rating = 0 };
            var course3 = new Course { CourseId = 3, CourseName = "Social Science", Rating = 0 };
            var course4 = new Course { CourseId = 4, CourseName = "History", Rating = 0 };
            var course5 = new Course { CourseId = 5, CourseName = "Geography", Rating = 0 };
            var course6 = new Course { CourseId = 6, CourseName = "English", Rating = 0 };
            var course7 = new Course { CourseId = 7, CourseName = "Marathi", Rating = 0 };
            var course8 = new Course { CourseId = 8, CourseName = "Kannada", Rating = 0 };
            var coursesList = new List<Course>() { course1, course2, course3, course4, course5, course6, course7, course8 };

            if (Courses != null && Courses.Count() >= 1)
            {
                Courses.RemoveRange(coursesList);
                SaveChanges();
            }
            Courses.AddRange(coursesList);
            SaveChanges();

        }
    }
}
