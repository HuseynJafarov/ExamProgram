using Microsoft.AspNetCore.Mvc;

namespace Exam.Admin.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
