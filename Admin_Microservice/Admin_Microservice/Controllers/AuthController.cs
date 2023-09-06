using Admin_Microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Admin_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly AdminDbContext _context;
        public AuthController(IConfiguration configuration, AdminDbContext context)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Admin user)
        {
            if (user != null && user.Username != null && user.Password != null)
            {
                var userData = await GetUser(user.Username, user.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if (userData != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", userData.Username),
                        new Claim("Password", userData.Password)

                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                       jwt.Issuer,
                       jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                    );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }


            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }
        [HttpGet]
        public async Task<Admin> GetUser(string name, string password)
        {
            return await _context.admin.FirstOrDefaultAsync(u => u.Username == name && u.Password == password);
        }
    }
}
