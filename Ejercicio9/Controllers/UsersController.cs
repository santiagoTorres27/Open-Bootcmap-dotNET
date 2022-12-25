using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly ILogger<AccountController> _logger;

        public UsersController(UniversityDBContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(GetUsers)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(GetUsers)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(GetUsers)} Critical Level Log");

            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/email
        [HttpGet("email/{email}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByEmail(string email)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(GetUsersByEmail)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(GetUsersByEmail)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(GetUsersByEmail)} Critical Level Log");

            return await _context.Users.Where(user => user.Email.Contains(email)).ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(GetUser)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(GetUser)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(GetUser)} Critical Level Log");

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(PutUser)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(PutUser)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(PutUser)} Critical Level Log");

            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(PostUser)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(PostUser)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(PostUser)} Critical Level Log");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(DeleteUser)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(DeleteUser)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(DeleteUser)} Critical Level Log");

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }


    }
}
