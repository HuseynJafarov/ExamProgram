using Microsoft.AspNetCore.Mvc;

namespace Exam.Admin.Controllers
{
    public class LessonController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }
    }
}
