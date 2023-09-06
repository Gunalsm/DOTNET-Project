using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PaperSetter_MicroService.Models

{
    public class PaperSetterDbContext : DbContext
    {
        public PaperSetterDbContext(DbContextOptions<PaperSetterDbContext> options) : base(options)
        {
        }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Questions> Question { get; set; }

        public DbSet<QuestionBank> QuestionBank { get; set; }

        public DbSet<PaperSetter> PaperSetter { get; set; }



    }
}
