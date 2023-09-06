using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Admin_Microservice.Models
{
    public class AdminDbContext:DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> admin { get; set; }
    }
}
