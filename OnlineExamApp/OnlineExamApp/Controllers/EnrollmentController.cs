using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineExamApp.Models;
using OnlineExamApp.ViewModels;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineExamApp.Controllers
{
    public class EnrollmentController : Controller
    {
        public async Task<IActionResult> CreateEnroll()
        {
            var viewmodel = new QuestionView();
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/api/Exam");
            var responseData = await response.Content.ReadFromJsonAsync<List<Exam>>();
            foreach (var i in responseData)
            {
                viewmodel.ExIds.Add(i.ExamId);
                viewmodel.ExNames.Add(i.ExamName);
             
            }
            return View(viewmodel);


        }

        [HttpPost]
        public async Task<IActionResult> CreateEnroll(QuestionView enroll)
        {
            var en = enroll.enrollment;
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7108/");

            HttpContent body = new StringContent(JsonConvert.SerializeObject(en), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/Enrollment", body);
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<Enrollment>(responseBody);
           // Console.ReadLine();
            return RedirectToAction("GetAllExamList", "Enrollment");

        }

        public async Task<IActionResult> GetAllExamList()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/api/Exam");
            var responseData = await response.Content.ReadFromJsonAsync<List<Exam>>();
            return View(responseData);

        }

        public async Task<IActionResult> GetAllEnroll()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7108/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/api/Enrollment");
            var responseData = await response.Content.ReadFromJsonAsync<List<Enrollment>>();
            return View(responseData);

        }

        public async Task<IActionResult> GetAllEnrollment()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7108/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string token = Request.Cookies["token"];
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var idClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "Email").Value;

            //Console.ReadLine();            // Pass the student's email as a query parameter
            HttpResponseMessage response = await client.GetAsync($"/api/Enrollment/{idClaim}");
            var responseData = await response.Content.ReadFromJsonAsync<List<Enrollment>>();
            return View(responseData);
            
            
        }









    }



}
