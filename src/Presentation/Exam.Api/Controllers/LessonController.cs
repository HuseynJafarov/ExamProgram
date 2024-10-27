using Application.Abstractions.Services;
using Application.DTOs.Lesson;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services;

namespace Exam.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLessons()
        {
            var result = await _lessonService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateLesson(LessonCreateAndUpdateDto lesson)
        {
            var result = await _lessonService.CreateAsync(lesson);
            return Ok(result);
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> UpdateLesson(int id, LessonCreateAndUpdateDto lesson)
        {
            var result = await _lessonService.UpdateAsync(id, lesson);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveLesson(int id)
        {
            var result = await _lessonService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPut("soft-delete/{id}")]
        public async Task<IActionResult> SoftDeleted(int id)
        {
            var result = await _lessonService.SoftDeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("search")] 
        public async Task<IActionResult> SearchLesson(string searchText)
        {
            var result = await _lessonService.SearchAsync(searchText);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _lessonService.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
