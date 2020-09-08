using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourses.Services;
using Microsoft.AspNetCore.Mvc;
using OnlineCourses.WebApiApp.Models.RequestModels;
using  OnlineCourses.WebApiApp.Models.ResponseModels;


namespace OnlineCourses.WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IEnumerable<CourseResponse>> GetCourses()
        {
            var courses = await _courseService.GetCourses();
            List<CourseResponse> courseResponse = new List<CourseResponse>();
            foreach (var course in courses)
            {
                courseResponse.Add(new CourseResponse { CourseId = course.CourseId, Rating = course.Rating, CourseName = course.CourseName });
            }
            return courseResponse;
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> PostCourses([FromBody] CourseRequest course)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCourse = new Services.ServiceModels.Course { Rating = course.Rating, CourseName = course.CourseName };
            var courseCreated = await _courseService.AddCourseAsync(newCourse);
            var courseResponse = new CourseResponse
            {
                CourseId = courseCreated.CourseId,
                Rating = courseCreated.Rating,
                CourseName = courseCreated.CourseName
            };
            return CreatedAtAction("GetCourses", new { id = courseResponse.CourseId }, courseResponse);


        }
        //// GET: api/Courses/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCourses([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var courses = await _context.Courses.FindAsync(id);

        //    if (courses == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(courses);
        //}

        //// PUT: api/Courses/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCourses([FromRoute] int id, [FromBody] Course courses)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != courses.CourseId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(courses).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CoursesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //// DELETE: api/Courses/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCourses([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var courses = await _context.Courses.FindAsync(id);
        //    if (courses == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Courses.Remove(courses);
        //    await _context.SaveChangesAsync();

        //    return Ok(courses);
        //}

        //private bool CoursesExists(int id)
        //{
        //    return _context.Courses.Any(e => e.CourseId == id);
        //}
    }
}