using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace TravelApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly TravelApiContext _db;

        public SecurityController(TravelApiContext db, IConfiguration configuration)
        {
            _db = db;
            _config = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IResult> CreateToken(AppUser user)
        {
            List<Users> userList = await _db.Users.ToListAsync();
            bool hasUser = userList.Any(us => us.UsersId == user.AppUserId);
            if (hasUser)
            {
                var issuer = _config["Jwt:Issuer"];
                var audience = _config["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes
                (_config["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.AppUserId.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return Results.Ok(stringToken);
            }
            return Results.Unauthorized();
        }
    }
}