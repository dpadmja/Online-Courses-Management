using System.Threading.Tasks;
using OnlineCourses.Repository.DBModels;
using Microsoft.EntityFrameworkCore;

namespace OnlineCourses.Repository
{
    public interface ICourseRepository
    {
        DbSet<Course> GetCourses();
        Task<Course> AddCourseAsync(Course course);
    }

}
