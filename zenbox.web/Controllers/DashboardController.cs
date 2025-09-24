using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.model;

namespace zenbox.web.Controllers
{
    [Authorize]
    public class DashboardController(IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager) : BaseController(webHostEnvironment, userManager)
    {
        [Route("/dashboard")]
        public IActionResult Index()
        {
            return View(
                new LayoutModel<DashboardModel>(new DashboardModel(), "Dashboard", sidebar));
        }
    }
}
