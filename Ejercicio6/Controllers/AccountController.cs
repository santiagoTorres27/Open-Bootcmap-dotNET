using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public AccountController(UniversityDBContext context, JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _context = context;
        }

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();

                var valid = _context.Users.Any(
                    user => user.Name.Equals(userLogins.UserName) && user.Password.Equals(userLogins.Password));

                if (valid)
                {
                    var user = _context.Users.FirstOrDefault(user => user.Name.Equals(userLogins.UserName));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        Username = user.Name,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid(),
                        Role = user.Role,
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Password");
                }

                return Ok(Token);
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
            return Ok();
        }
    }
}
