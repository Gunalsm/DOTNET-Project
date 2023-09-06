using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExamApp.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string QuestionName { get; set; }
        [Required]
        public string Option1 { get; set; }
        [Required]

        public string Option2 { get; set; }
        [Required]
        public string Option3 { get; set; }
        [Required]
        public string Option4 { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }

        [ForeignKey("QuestionBankId")]
        public int QuestionBankId { get; set; }
    }
}
