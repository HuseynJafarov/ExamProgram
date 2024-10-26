using Microsoft.AspNetCore.Mvc;

namespace Exam.Admin.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILogger<LessonController> _logger;

        public LessonController(ILogger<LessonController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
