using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineExamApp.Models;
using OnlineExamApp.ViewModels;
using System.Net.Http.Headers;
using System.Text;

namespace OnlineExamApp.Controllers
{
    public class QuestionBankController : Controller
    {


        //    public IActionResult CreateQuestionBank()
        //    {
        //        return View();
        //    }
        //    // Frontend Controller
        //    //[Authorize]
        //    [HttpPost]
        //    public async Task<IActionResult> CreateQuestionBank(QuestionBank question)
        //    {
        //        using var client = new HttpClient();
        //        client.BaseAddress = new Uri("https://localhost:7180/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = await client.PostAsJsonAsync("/api/QuestionBank", question);
        //        Console.ReadLine();

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var responseData = await response.Content.ReadFromJsonAsync<QuestionBank>();

        //            // Redirect to the CreateQuestions page, passing the newly created question bank's ID
        //            return RedirectToAction("CreateQuestion", new { questionBankId = responseData.QuestionBankId });
        //        }
        //        else
        //        {
        //            // Handle the case when the request fails
        //            return StatusCode((int)response.StatusCode);
        //        }
        //    }

        //    //[HttpGet("QuestionBankId")]
        //    //public async Task<IActionResult> GetQuestionBanks(int QuestionBankId)
        //    //{
        //    //    using var client = new HttpClient();
        //    //    client.BaseAddress = new Uri("https://localhost:7180/");
        //    //    client.DefaultRequestHeaders.Accept.Clear();
        //    //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    //    HttpResponseMessage response = await client.GetAsync($"/api/QuestionBank{QuestionBankId}");

        //    //    if (response.IsSuccessStatusCode)
        //    //    {
        //    //        var json = await response.Content.ReadAsStringAsync();
        //    //        //var responseData = JsonConvert.DeserializeObject<IEnumerable<QuestionBank>>(json);

        //    //        // Process the responseData as needed

        //    //        // Redirect to the CreateQuestions page, passing the newly created question bank's ID
        //    //        // return RedirectToAction("CreateQuestion", new { questionBankId = responseData.QuestionBankId });
        //    //    }


        //    //    return View();
        //    //}







        //    //[HttpPost]
        //    //public async Task<IActionResult> CreateQuestion(QuestionCreateDto question)
        //    //{
        //    //    using var client = new HttpClient();
        //    //    client.BaseAddress = new Uri("https://localhost:7180/");
        //    //    client.DefaultRequestHeaders.Accept.Clear();
        //    //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    //    HttpResponseMessage response = await client.PostAsJsonAsync("/api/Questions", question);

        //    //    if (response.IsSuccessStatusCode)
        //    //    {
        //    //        var responseData = await response.Content.ReadFromJsonAsync<Questions>();
        //    //        return Ok(responseData);
        //    //    }
        //    //    else
        //    //    {
        //    //        // Handle the case when the request fails
        //    //        return StatusCode((int)response.StatusCode);
        //    //    }
        //    //}

        //    [HttpGet("QuestionBankId")]

        //    public async Task<IActionResult> GetQuestionForQB(int QuestionBankId)
        //    {
        //        using var client = new HttpClient();
        //        client.BaseAddress = new Uri("https://localhost:7180/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = await client.GetAsync($"/api/Questions/{QuestionBankId}");

        //            var json = await response.Content.ReadAsStringAsync();
        //            var responseData = JsonConvert.DeserializeObject<IEnumerable<Questions>>(json);


        //            // Process the responseData as needed

        //            // Redirect to the CreateQuestions page, passing the newly created question bank's ID
        //            // return RedirectToAction("CreateQuestion", new { questionBankId = responseData.QuestionBankId });



        //        return View(responseData);

        //    }


        //}
        public async Task<IActionResult> GetQuestionBanks() {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/api/QuestionBank");
            var responseData = await response.Content.ReadFromJsonAsync<List<QuestionBank>>();
            return View(responseData);

        }

        public IActionResult CreateQuestionBank()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestionBank(QuestionBank question)
        {
            var viewmodel = new QuestionView();
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/");
            var qb = new QuestionBank()
            {
                QuestionBankName = question.QuestionBankName,

            };


            HttpContent body = new StringContent(JsonConvert.SerializeObject(qb), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/QuestionBank", body);
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<QuestionBank>(responseBody);
            var id = responseObject.QuestionBankId;
            var name = responseObject.QuestionBankName;
            viewmodel.qbIds.Add(id);
            viewmodel.qbNames.Add(name);
            return RedirectToAction("GetQuestionBanks");



        }

    }
}
