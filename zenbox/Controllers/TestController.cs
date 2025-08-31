using Microsoft.AspNetCore.Mvc;

namespace zenbox.web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
