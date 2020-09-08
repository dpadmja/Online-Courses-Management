using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCourses.Services.ServiceModels;

namespace OnlineCourses.Services
{
    public interface ICourseService
    {
       Task<IEnumerable<Course>> GetCourses();
       Task<Course> AddCourseAsync(Course course);
    }
}
