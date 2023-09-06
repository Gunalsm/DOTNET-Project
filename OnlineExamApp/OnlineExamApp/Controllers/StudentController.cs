using Microsoft.AspNetCore.Mvc;
using OnlineExamApp.Models;
using System.Net.Http.Headers;

namespace OnlineExamApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DisplayAllExams()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/api/Exam");
            var responseData = await response.Content.ReadFromJsonAsync<List<Exam>>();
            return View(responseData);

        }

       
        }





    }

