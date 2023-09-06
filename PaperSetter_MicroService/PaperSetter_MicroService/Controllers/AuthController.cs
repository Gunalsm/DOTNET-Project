using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaperSetter_MicroService.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaperSetter_MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly PaperSetterDbContext _context;
        public AuthController(IConfiguration configuration, PaperSetterDbContext context)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Post(PaperSetterDto paperSetter)
        {
            if (paperSetter != null && paperSetter.Email != null && paperSetter.Password != null)
            {
                var userData = await GetUser(paperSetter.Email, paperSetter.Password);
                int id = userData.Id;
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if (userData != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id",id.ToString()),
                        new Claim("Email", userData.Email),
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
        public async Task<PaperSetter> GetUser(string email, string password)
        {
            return await _context.PaperSetter.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

    }
}
