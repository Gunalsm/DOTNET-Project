using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineExamApp.Models;
using System.Text;

namespace OnlineExamApp.Controllers
{
    public class AdminLoginController:Controller
    {
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AdminLogin(Admin admin)
        {


            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7031/");

            var login = new Admin()
            {
                //UserId = int.Parse(Console.ReadLine()),
                Username = admin.Username,
                Password = admin.Password,

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

                string token = Request.Cookies["token"];
                if (token != null)
                {
                    return RedirectToAction("AdminView", "Home");

                    //return RedirectToAction("Index");//Action, Controller
                }

            }
            return View();
        }
    }
}
