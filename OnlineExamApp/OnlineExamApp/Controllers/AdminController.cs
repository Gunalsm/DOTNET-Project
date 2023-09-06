using Microsoft.AspNetCore.Mvc;
using OnlineExamApp.Models;
using System.Net.Http.Headers;

namespace OnlineExamApp.Controllers
{
    public class AdminController:Controller
    {
        public async Task<IActionResult> StudentList()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7108/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"/api/Student");
            var responseData = await response.Content.ReadFromJsonAsync<List<Student>>();

            return View(responseData);
        }


        public async Task<IActionResult> QuestionBankList()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"/api/QuestionBank");
            var responseData = await response.Content.ReadFromJsonAsync<List<QuestionBank>>();

            return View(responseData);
        }

        public async Task<IActionResult> ExamList()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"/api/Exam");
            var responseData = await response.Content.ReadFromJsonAsync<List<Exam>>();

            return View(responseData);
        }




    }
}
