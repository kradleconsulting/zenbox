using Microsoft.AspNetCore.Mvc;

namespace zenbox.web.Controllers
{
    public class MaterialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
