using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid id)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id", userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.Username),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt")),
            };


            if (userAccounts.Role == "Administrator")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }
            else if (userAccounts.Role == "User")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                //claims.Add(new Claim("UserOnly", "User 1"));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }

        public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                // Obtain secret key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);

                Guid Id;

                // Expires in 1 day
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // Validity of our token
                userToken.Validity = expireTime.TimeOfDay;

                // Generate our JWT
                var jwToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        //jwtSettings.ValidIssuer,
                        SecurityAlgorithms.HmacSha256));

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                userToken.Username = model.Username;
                userToken.Id = model.Id;
                userToken.GuidId = Id;
                userToken.Role = model.Role;

                return userToken;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Generatng the JWT", ex);
            }
        }
    }
}
