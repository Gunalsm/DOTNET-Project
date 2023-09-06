using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaperSetter_MicroService.Models;
using PaperSetter_MicroService.Services;

namespace PaperSetter_MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionBankController : ControllerBase
    {
        private readonly IQuestionBankRepository _questionBankRepository;
       


        public QuestionBankController(IQuestionBankRepository questionBankRepository)
        {
           _questionBankRepository = questionBankRepository;
           
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestionBank(QuestionBank que)
        {
            var questionBank = await _questionBankRepository.CreateQuestionBankAsync(que);

            return Ok(questionBank);
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionBank>>> GetAllQB()
        {

            var qb = await _questionBankRepository.GetQuestionBankAsync();

            return Ok(qb);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<QuestionBankCreateDto>>> GetAllQBs()
        //{
        //    var qbs = await _mapperRepository.GetQuestionBanks();
        //    return Ok(qbs);
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<QuestionBankCreateDto>>> GetAllQBs()
        //{

        //    var qbs = await _questionBankRepository.GetQuestionBanks();

        //    return Ok(qbs);
        //}

        [HttpGet("{questionbankId}")]
        public async Task<IActionResult> GetQuestions(int questionbankId)
        {
            var ques = await _questionBankRepository.GetQuestionsAsync(questionbankId);
            if (ques == null)
            {
                return NotFound();
            }

           

            return Ok(ques);
        }
    }
}
