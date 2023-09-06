using OnlineExamApp.Models;

namespace OnlineExamApp.ViewModels
{
    public class QuestionView
    {
        public Questions questions { get; set; }
        public Exam exam { get; set; }
         public List<int> qbIds = new List<int>();
        public List<string> qbNames = new List<string>();
        public List<int> ExIds = new List<int>();
        public List<string> ExNames = new List<string>();      
        
        public Enrollment enrollment { get; set; }
    }
}
