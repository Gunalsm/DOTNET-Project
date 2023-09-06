using Admin_Microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminDbContext _context;

        public AdminController(AdminDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostUser(Admin user)
        {


            _context.Add(user);
            _context.SaveChanges();


            return Ok();
        }
    }
}
