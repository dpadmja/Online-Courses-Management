using System.Threading.Tasks;
using OnlineCourses.Repository.DBModels;
using Microsoft.EntityFrameworkCore;

namespace OnlineCourses.Repository
{
    public class CoursesRepository : ICourseRepository
    {
        private readonly CoursesDbContext _context;

        public CoursesRepository(CoursesDbContext context)
        {
            _context = context;
        }

        private async Task SaveToDataBaseAsync()
        {
            await _context.SaveChangesAsync();
        }
        public DbSet<Course> GetCourses()
        {
            return _context.Courses;
        }
        public async Task<Course> AddCourseAsync(OnlineCourses.Repository.DBModels.Course course)
        {
            var lastResult = await _context.Courses.LastOrDefaultAsync();

            var newId = lastResult.CourseId+1;
            course.CourseId = newId;
            await _context.Courses.AddAsync(course);
            await SaveToDataBaseAsync();
            return course;
        }
    }
}
