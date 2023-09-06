using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExamApp.Models
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

       // public ICollection<QuestionBank> QuestionBanks { get; set; } = new List<QuestionBank>();

    }
}
