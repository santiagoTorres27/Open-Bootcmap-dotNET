using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;
using UniversityApiBackend.Services;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        private readonly ICourseService _coursesService;

        public CoursesController(UniversityDBContext context, ICourseService courseService)
        {
            _context = context;
            _coursesService = courseService;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        // GET COURSES BY CATEGORY
        // GET api/Courses/{categoryId}
        [HttpGet("category/{categoryID}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByCategory(int categoryId)
        {
            return NoContent();
        }

        // GET COURSES WITHOUT CHAPTERS
        // GET api/Courses/noChapters
        [HttpGet("noChapters")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesWithoutChapters()
        {
            return NoContent();
        }

        // GET COURSE CHAPTER
        // GET api/Courses/1/Chapter
        [HttpGet("{courseId}/Chapter")]
        public async Task<ActionResult<Chapter>> GetCourseChapter(int courseId)
        {
            return NoContent();
        }

        // GET COURSE BY STUDENT
        // GET api/Courses/Student/{idStudent}
        [HttpGet("Student/{idStudent}")]
        public async Task<ActionResult<Chapter>> GetCoursesByStudent(int idStudent)
        {
            return NoContent();
        }
    }
}
