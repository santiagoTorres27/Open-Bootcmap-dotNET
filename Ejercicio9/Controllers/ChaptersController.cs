using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly ILogger<AccountController> _logger;

        public ChaptersController(UniversityDBContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Chapters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChapters()
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(GetChapters)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(GetChapters)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(GetChapters)} Critical Level Log");

            return await _context.Chapters.ToListAsync();
        }

        // GET: api/Chapters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chapter>> GetChapter(int id)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(GetChapter)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(GetChapter)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(GetChapter)} Critical Level Log");

            var chapter = await _context.Chapters.FindAsync(id);

            if (chapter == null)
            {
                return NotFound();
            }

            return chapter;
        }

        // PUT: api/Chapters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutChapter(int id, Chapter chapter)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(PutChapter)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(PutChapter)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(PutChapter)} Critical Level Log");

            if (id != chapter.Id)
            {
                return BadRequest();
            }

            _context.Entry(chapter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapterExists(id))
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

        // POST: api/Chapters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Chapter>> PostChapter(Chapter chapter)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(PostChapter)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(PostChapter)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(PostChapter)} Critical Level Log");

            _context.Chapters.Add(chapter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChapter", new { id = chapter.Id }, chapter);
        }

        // DELETE: api/Chapters/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(DeleteChapter)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(DeleteChapter)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(DeleteChapter)} Critical Level Log");

            var chapter = await _context.Chapters.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }

            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChapterExists(int id)
        {
            return _context.Chapters.Any(e => e.Id == id);
        }
    }
}
