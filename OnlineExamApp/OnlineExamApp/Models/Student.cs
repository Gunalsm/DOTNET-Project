using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExamApp.Models
{
    public class Student
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        [ForeignKey("ExamId")]

        public int ExamId { get; set; }
    }
}
