using Microsoft.AspNetCore.Mvc;

namespace Exam.Admin.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
