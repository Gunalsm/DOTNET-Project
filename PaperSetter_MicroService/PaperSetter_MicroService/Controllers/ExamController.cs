using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaperSetter_MicroService.Models;
using PaperSetter_MicroService.Services;

namespace PaperSetter_MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        private readonly IQuestionBankRepository _questionBankRepository;


        public ExamController(IQuestionBankRepository questionBankRepository)
        {
            _questionBankRepository = questionBankRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateExam(Exam exam)
        {
            var ex = await _questionBankRepository.CreateExamAsync(exam);

            return Ok(ex);
        }
        [HttpDelete("{examId}")]
        public async Task<IActionResult> DeleteExam(int examId)
        {
            var deleted = await _questionBankRepository.DeleteExamAsync(examId);
            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExam()
        {
            var exam = await _questionBankRepository.GetAllExamAsync();
            if (exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }

        //[HttpGet("{examId}")]
        //public async Task<IActionResult> GetExamAsync(int examId)
        //{
        //    var exam = await _questionBankRepository.GetExamAsync(examId);
        //    if (exam == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(exam);
        //}


    }
}
