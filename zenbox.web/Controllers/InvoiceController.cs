using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.model;

namespace zenbox.web.Controllers
{
    [Authorize]
    [Route("/invoices")]
    public class InvoiceController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager) : BaseController(httpContextAccessor, webHostEnvironment, userManager)
    {
        public IActionResult Index()
        {
            return View(
                new LayoutModel<InvoiceViewmodel>(new InvoiceViewmodel(), "Invoice", sidebar) );
        }
    }
}
