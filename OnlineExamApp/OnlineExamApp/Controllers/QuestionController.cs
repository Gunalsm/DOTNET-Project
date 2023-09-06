using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineExamApp.Models;
using OnlineExamApp.ViewModels;
using System.Net.Http.Headers;
using System.Text;

namespace OnlineExamApp.Controllers
{
    public class QuestionController : Controller
    {
        public async Task<IActionResult> CreateQuestion()
        {
            var viewmodel = new QuestionView();
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/api/QuestionBank");
            var responseData = await response.Content.ReadFromJsonAsync<List<QuestionBank>>();
            foreach(var i in responseData)
            {
                viewmodel.qbIds.Add(i.QuestionBankId);
                viewmodel.qbNames.Add(i.QuestionBankName);
            }
            return View(viewmodel);

           
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(QuestionView question)
        {
            var ques = question.questions;
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");

            HttpContent body = new StringContent(JsonConvert.SerializeObject(ques), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/Questions", body);
           
            return RedirectToAction("GetQuestionBanks","QuestionBank");

        }

    }
}
