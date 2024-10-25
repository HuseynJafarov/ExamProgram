using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateExam()
        {
            return Ok();
        }

    }
}
