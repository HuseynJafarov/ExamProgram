using Application.Abstractions.Services;
using Application.DTOs.Student;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _studentService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentCreateAndUpdateDto student)
        {
            var result = await _studentService.CreateAsync(student);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(int id,StudentCreateAndUpdateDto student)
        {
            var result = await _studentService.UpdateAsync(id,student);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveStudent(int id)
        {
            var result = await _studentService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> SoftDeleted(int id)
        {
            var result = await _studentService.SoftDeleteAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SearchStudent(string searchText)
        {
            var result = await _studentService.SearchAsync(searchText);
            return Ok(result);
        }


    }
}