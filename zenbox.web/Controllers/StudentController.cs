using Microsoft.AspNetCore.Mvc;

namespace zenbox.web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
