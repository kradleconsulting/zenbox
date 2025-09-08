using Microsoft.AspNetCore.Mvc;

namespace zenbox.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
