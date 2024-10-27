using Exam.Admin.Models.Student;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Exam.Admin.Controllers
{
    public class StudentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StudentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("ExamApiClient");

            var response = await client.GetAsync("Student/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var studentsJson = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<StudentList>>(studentsJson);

                return View(students);
            }

            return View("Error");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreate student)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("ExamApiClient");
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Student/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Student not Created");
            }

            return View(student);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("ExamApiClient");
            var response = await client.GetAsync($"Student/GetById/{id}"); 

            if (response.IsSuccessStatusCode)
            {
                var studentJson = await response.Content.ReadAsStringAsync();
                var student = JsonConvert.DeserializeObject<StudentList>(studentJson); 

                return View(student);
            }

            return NotFound(); 
        }


        [HttpPost]
        public async Task<IActionResult> Edit(StudentList student)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("ExamApiClient");
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"Student/Edit/{student.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Student not updated");
            }

            return View(student);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("ExamApiClient");

            var response = await client.DeleteAsync($"Student/Delete/{id}");

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

            var response = await client.PutAsync($"Student/soft-delete/{id}",null);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }
    }
}
