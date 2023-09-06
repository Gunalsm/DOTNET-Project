using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineExamApp.Models;
using System.Text;

namespace OnlineExamApp.Controllers
{
    public class PaperSetterRegister : Controller
    {
        public IActionResult PostPaperSetter()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> PostPaperSetter(PaperSetter paperSetter)
        {


            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");

            var register = new PaperSetter()
            {
                //UserId = int.Parse(Console.ReadLine()),
                Name = paperSetter.Name,
                Email = paperSetter.Email,
                Password = paperSetter.Password,
                ConfirmPassword = paperSetter.ConfirmPassword,
            };

            HttpContent body = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var response = client.PostAsync("/api/PaperSetter", body).Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();


            //    Response.Cookies.Append("token", content, new CookieOptions
            //    {
            //        Expires = DateTime.Now.AddMinutes(1),
            //        HttpOnly = true,
            //        Secure = true,
            //        SameSite = SameSiteMode.None
            //    });

            //    string token = Request.Cookies["token"];
            //    if (token != null)
            //    {
            //        return RedirectToAction("LoginPaperSetter", "Login");
            //    }

            //}

            if (response.IsSuccessStatusCode)
            {
                // Registration successful
                return RedirectToAction("LoginPaperSetter", "PaperSetterLogin");
            }
            return View();
        }
    }
}
