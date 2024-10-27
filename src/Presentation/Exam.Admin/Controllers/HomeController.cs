using Microsoft.AspNetCore.Mvc;

namespace Exam.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
