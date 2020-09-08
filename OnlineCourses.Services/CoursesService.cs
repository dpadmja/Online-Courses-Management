using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineCourses.Repository;
using OnlineCourses.Services.ServiceModels;

namespace OnlineCourses.Services
{
    public class CoursesService : ICourseService
    {
        private readonly ICourseRepository _coursesRepo;

        public CoursesService(ICourseRepository coursesRepo)
        {
            _coursesRepo = coursesRepo;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            //Todo: use automapper here

            var courses = _coursesRepo.GetCourses();
            List<Course> coursesList = null;
            if (courses != null)
            {
                coursesList = new List<Course>();
                await courses.ForEachAsync(crs =>
                  {
                      coursesList.Add(
                            new Course { CourseId = crs.CourseId, CourseName = crs.CourseName, Rating = crs.Rating });
                  });
            }

            return coursesList;
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            Repository.DBModels.Course newCourse = new OnlineCourses.Repository.DBModels.Course() { Rating = course.Rating, CourseName = course.CourseName };
            var courseCreated = await _coursesRepo.AddCourseAsync(newCourse);
            return new Course()
            {
                Rating = courseCreated.Rating,
                CourseName = courseCreated.CourseName,
                CourseId = courseCreated.CourseId
            };
        }


    }
}
