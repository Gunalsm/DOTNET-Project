using System.ComponentModel.DataAnnotations;

namespace OnlineExamApp.Models
{
    public class Enrollment
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int EnrollmentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string StudentEmail { get; set; }

        [Required]
        public int ExamId { get; set; }

    }
}
