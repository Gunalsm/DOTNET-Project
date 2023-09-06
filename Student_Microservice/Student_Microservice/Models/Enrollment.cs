using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Microservice.Models
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

       
        public Exam Exam { get; set; } 


    }
}
