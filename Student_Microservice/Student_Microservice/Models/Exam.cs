using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Student_Microservice.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ExamName { get; set; }

        public DateTime Exam_StartDateTime { get; set; }
        public DateTime Exam_EndDateTime { get; set; }

        public string Exam_Duration { get; set; }

        [ForeignKey("QuestionBankId")]
        public int QuestionBankId { get; set; }
    }
}
