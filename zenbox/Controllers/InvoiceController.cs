using Microsoft.AspNetCore.Mvc;

namespace zenbox.web.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
