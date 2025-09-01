using Microsoft.AspNetCore.Mvc;

namespace zenbox.web.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
