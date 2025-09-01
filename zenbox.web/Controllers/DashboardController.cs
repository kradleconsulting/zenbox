using Microsoft.AspNetCore.Mvc;

namespace zenbox.web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
