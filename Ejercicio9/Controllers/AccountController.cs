using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Helpers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly JwtSettings _jwtSettings;
        private readonly IStringLocalizer<AccountController> _stringLocalizer;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UniversityDBContext context, JwtSettings jwtSettings, IStringLocalizer<AccountController> stringLocalizer, ILogger<AccountController> logger)
        {
            _jwtSettings = jwtSettings;
            _context = context;
            _stringLocalizer = stringLocalizer;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(GetToken)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(GetToken)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(GetToken)} Critical Level Log");

            try
            {
                var message = _stringLocalizer["Message"];

                var Token = new UserTokens();

                var searchUser = (from user in _context.Users
                                  where user.Name == userLogin.UserName
                                  && user.Password == userLogin.Password
                                  select user).FirstOrDefault();

                if (searchUser != null)
                {
                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        Username = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                        Role = searchUser.Role,
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Password");
                }

                return Ok(
                    new
                    {
                        Token,
                        Message = message.Value
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error ", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            // Logs
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(GetUserList)} Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(GetUserList)} Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(GetUserList)} Critical Level Log");
            return Ok();
        }
    }
}
