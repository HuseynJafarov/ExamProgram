using Exam.Admin.Models.Exam;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Admin.Controllers
{
    public class ExamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("ExamApiClient");
            var response = await client.GetAsync("Exam/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var examsJson = await response.Content.ReadAsStringAsync();
                var exams = JsonConvert.DeserializeObject<List<ExamList>>(examsJson);

                if (exams != null)
                {
                    return View(exams);
                }
            }

            return View("Error");
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamCreate exam)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("ExamApiClient");
                var json = JsonConvert.SerializeObject(exam);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Exam/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Exam not created");
            }

            return View(exam);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("ExamApiClient");
            var response = await client.GetAsync($"Exam/GetById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var examJson = await response.Content.ReadAsStringAsync();
                var exam = JsonConvert.DeserializeObject<ExamList>(examJson);

                return View(exam);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExamList exam)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("ExamApiClient");
                var json = JsonConvert.SerializeObject(exam);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"Exam/Edit/{exam.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Exam not updated");
            }

            return View(exam);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("ExamApiClient");

            var command = new { Id = id };
            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.DeleteAsync($"Exam/Delete/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }



    }
}
