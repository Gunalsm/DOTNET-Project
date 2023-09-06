
using PaperSetter_MicroService.Models;
namespace PaperSetter_MicroService.Services
{
    public interface IQuestionBankRepository
    {
        Task<IEnumerable<QuestionBank>> GetQuestionBankAsync();

        //Task<IEnumerable<QuestionBankCreateDto>> GetQuestionBanks();

        Task<QuestionBank> GetQuestionsAsync(int questionBankId);

        Task<QuestionBank> CreateQuestionBankAsync(QuestionBank questionBank);
        Task<IEnumerable<Questions>> GetquestionsForquestionbankAsync(int questionBankId);
        Task<Questions?> GetquestionForquestionbankAsync(int questionBankId,
            int questionId);
        Task AddQuestionsForQuestionBankAsync(Questions questions);

        Task<Exam> CreateExamAsync(Exam exam);

        Task<bool> DeleteExamAsync(int examId);
        Task<Exam> GetExamAsync(int examId);

        Task<IEnumerable<Exam> > GetAllExamAsync();
        Task<bool> SaveChangesAsync();
        
    }
}
