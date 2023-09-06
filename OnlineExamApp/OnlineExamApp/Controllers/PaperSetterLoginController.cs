using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineExamApp.Models;
using System.Text;

namespace OnlineExamApp.Controllers
{
    public class PaperSetterLoginController : Controller
    {
        public IActionResult LoginPaperSetter()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> LoginPaperSetter(PaperSetter paperSetter)
        {


            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");

            var login = new PaperSetter()
            {
                //UserId = int.Parse(Console.ReadLine()),
                Email = paperSetter.Email,
                Password = paperSetter.Password,
            };

            HttpContent body = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var response = client.PostAsync("/api/Auth", body).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();


                Response.Cookies.Append("token", content, new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(1),
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None
                });

                return RedirectToAction("CreateQuestionBank", "QuestionBank");

            }
            return View();
        }
    }
}
