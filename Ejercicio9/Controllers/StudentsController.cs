using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;
using UniversityApiBackend.Services;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly ILogger<AccountController> _logger;

        // Services
        private readonly IStudentsService _studentsService;

        public StudentsController(UniversityDBContext context, IStudentsService studentsService, ILogger<AccountController> logger)
        {
            _context = context;
            _studentsService = studentsService;
            _logger = logger;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(GetStudents)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(GetStudents)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(GetStudents)} Critical Level Log");

            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(GetStudent)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(GetStudent)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(GetStudent)} Critical Level Log");

            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(PutStudent)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(PutStudent)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(PutStudent)} Critical Level Log");

            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(PostStudent)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(PostStudent)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(PostStudent)} Critical Level Log");

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(DeleteStudent)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(DeleteStudent)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(DeleteStudent)} Critical Level Log");

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
