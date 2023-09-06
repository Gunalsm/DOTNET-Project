using Microsoft.EntityFrameworkCore;

namespace Student_Microservice.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get;set; }

       
        public DbSet<Enrollment> Enrollments { get;set; }

    }



}
