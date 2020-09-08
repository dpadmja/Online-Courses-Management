using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.Repository.DBModels
{
    public class Course
    {
        public Course()
        {
            
        }
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Rating { get; set; }
    }
}
