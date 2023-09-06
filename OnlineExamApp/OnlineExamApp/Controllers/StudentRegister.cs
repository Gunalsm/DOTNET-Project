using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineExamApp.Models;
using System.Text;

namespace OnlineExamApp.Controllers
{
    public class StudentRegister : Controller
    {
        public IActionResult PostStudent()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> PostStudent(Student student)
        {


            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7108/");

            var register = new Student()
            {
                //UserId = int.Parse(Console.ReadLine()),
                Name = student.Name,
                Email = student.Email,
                Password = student.Password,
                ConfirmPassword = student.ConfirmPassword,
            };

            HttpContent body = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var response = client.PostAsync("/api/Student", body).Result;

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
                return RedirectToAction("LoginStudent", "StudentLogin"); //action //controller
            }
            return View();
        }
    }
}
