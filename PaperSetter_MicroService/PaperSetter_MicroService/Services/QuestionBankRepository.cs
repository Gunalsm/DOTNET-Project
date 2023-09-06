using Microsoft.EntityFrameworkCore;
using PaperSetter_MicroService.Models;


namespace PaperSetter_MicroService.Services
{
    public class QuestionBankRepository: IQuestionBankRepository
    {
        private readonly PaperSetterDbContext _context;

        public QuestionBankRepository(PaperSetterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuestionBank>> GetQuestionBankAsync()

        {
            return await _context.QuestionBank.Include(c => c.Questions).ToListAsync();

        }


        public async Task<QuestionBank?> GetQuestionsAsync(int questionBankId)
        {
            return await _context.QuestionBank.Include(c => c.Questions)
                   .Where(c => c.QuestionBankId == questionBankId).FirstOrDefaultAsync();



        }
        public async Task<QuestionBank> CreateQuestionBankAsync(QuestionBank questionBank)
        {
          
            _context.QuestionBank.Add(questionBank);
            await _context.SaveChangesAsync();

            return questionBank;
        }

        public async Task<Exam> CreateExamAsync(Exam exam)
        {

            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();

            return exam;
        }


        public async Task<Questions?> GetquestionForquestionbankAsync(
            int questionBankId,
            int questionId)
        {
            return await _context.Question
               .Where(p => p.QuestionBankId == questionBankId && p.Id == questionId)
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Questions>> GetquestionsForquestionbankAsync(
            int questionBankId)
        {
            return await _context.Question
                           .Where(p => p.QuestionBankId == questionBankId).ToListAsync();
        }

        //public async Task<IEnumerable<QuestionBankCreateDto>> GetQuestionBanks()
        //{
        //   return Iawait _context.QuestionBank.ToListAsync();
        //}
        public async Task AddQuestionsForQuestionBankAsync(
            Questions questions)
        {
            await _context.Question.AddAsync(questions);
            
        }
        public async Task<bool> DeleteExamAsync(int examId)
        {
            var exam = await _context.Exams.FindAsync(examId);
            if (exam == null)
            {
                return false; // Exam not found
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Exam> GetExamAsync(int examId)
        {
            return await _context.Exams.FindAsync(examId);
        }
        public async Task<IEnumerable<Exam>> GetAllExamAsync()
        {
            return await _context.Exams.ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

       
    }

}
