using Microsoft.AspNetCore.Mvc;
using OnlineExamApp.Models;
using System.Net.Http.Headers;

namespace OnlineExamApp.Controllers
{
    public class StartTestController : Controller
    {



        [HttpGet("QuestionBankId")]

        public async Task<IActionResult> GetQuestionList(int questionBankId)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync($"/api/Questions/QuestionBankId?QuestionBankId={questionBankId}");
            var responseData = await response.Content.ReadFromJsonAsync<List<Questions>>();
            return View(responseData);
        }

        //public async Task<IActionResult> GetQuestionList(int QuestionBankId)
        //{
        //    using var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:7180/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    HttpResponseMessage response = await client.GetAsync($"/api/Questions/{QuestionBankId}");
        //    var responseData = await response.Content.ReadFromJsonAsync<List<Questions>>();
        //    return View(responseData);


        //}


    }
}
