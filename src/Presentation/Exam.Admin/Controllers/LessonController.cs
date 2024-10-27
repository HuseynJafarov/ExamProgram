using Exam.Admin.Models.Lesson;
using Exam.Admin.Models.Student;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Exam.Admin.Controllers
{
    public class LessonController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LessonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("ExamApiClient");

            var response = await client.GetAsync("Lesson/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var lessonsJson = await response.Content.ReadAsStringAsync();
                var lessons = JsonConvert.DeserializeObject<List<LessonList>>(lessonsJson);

                return View(lessons);
            }

            return View("Error");
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LessonCreate lessons)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("ExamApiClient");
                var json = JsonConvert.SerializeObject(lessons);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Lesson/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Lesson not Created");
            }

            return View(lessons);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("ExamApiClient");
            var response = await client.GetAsync($"Lesson/GetById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var lessonJson = await response.Content.ReadAsStringAsync();
                var lesson = JsonConvert.DeserializeObject<StudentList>(lessonJson);

                return View(lesson);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(LessonList lesson)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("ExamApiClient");
                var json = JsonConvert.SerializeObject(lesson);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"Lesson/Edit/{lesson.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Lesson not updated");
            }

            return View(lesson);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("ExamApiClient");

            var response = await client.DeleteAsync($"Lesson/Delete/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }


        [HttpPost]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var client = _httpClientFactory.CreateClient("ExamApiClient");

            var response = await client.PutAsync($"Lesson/soft-delete/{id}", null);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }
    }
}
