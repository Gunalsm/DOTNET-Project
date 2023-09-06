using Microsoft.AspNetCore.Mvc;
using OnlineExamApp.Models;
using System.Net.Http.Headers;

namespace OnlineExamApp.Controllers
{
    public class PaperSetterListController : Controller
    {
        public async Task<IActionResult> SetterList()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"/api/PaperSetter");
            var responseData = await response.Content.ReadFromJsonAsync<List<PaperSetter>>();

            return View(responseData);
        }
    }
}
