using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaperSetter_MicroService.Models
{
  
    public class QuestionBank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionBankId { get; set; }

        [Required]
        [MaxLength(500)]
        public string QuestionBankName { get; set; }

        public ICollection<Questions> Questions { get; set; } = new List<Questions>();
    }
}
