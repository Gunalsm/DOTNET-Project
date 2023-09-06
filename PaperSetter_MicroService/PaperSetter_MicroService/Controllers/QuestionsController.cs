using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaperSetter_MicroService.Models;
using PaperSetter_MicroService.Services;

namespace PaperSetter_MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionBankRepository _questionBankRepository;
        public QuestionsController(IQuestionBankRepository questionBankRepository) {
            _questionBankRepository = questionBankRepository;
        }


        //[HttpGet("{QuestionBankId}")]
        //public async Task<ActionResult<IEnumerable<Questions>>> GetQuestions(int QuestionBankId)
        //{
        //    var questionInQB = await _questionBankRepository.GetquestionsForquestionbankAsync(QuestionBankId);
        //    return Ok(questionInQB);
        //}

        [HttpGet("QuestionBankId")]
        public async Task<ActionResult<IEnumerable<Questions>>> GetQuestions(int QuestionBankId)
        {

            var questionInQB = await _questionBankRepository.GetquestionsForquestionbankAsync(QuestionBankId);

            return Ok(questionInQB);
        }

        //[HttpGet("{questionId}")]
        //public async Task<ActionResult<Questions>> GetQuestion(int questionId, int qBId)
        //{
        //    var question = await _questionBankRepository.GetquestionForquestionbankAsync(questionId, qBId);

       
        //    return Ok(question);
        //}

        [HttpPost]
        public async Task<ActionResult<Questions>> CreatePointOfInterest(
           Questions ques)
        {

            await _questionBankRepository.AddQuestionsForQuestionBankAsync(ques);

            await _questionBankRepository.SaveChangesAsync();

            return Ok(ques);

          
        }
    }
}
