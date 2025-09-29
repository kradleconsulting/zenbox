using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.model;

namespace zenbox.web.Controllers
{
    [Authorize]
    [Route("/tests")]
    public class TestController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager) : BaseController(httpContextAccessor, webHostEnvironment, userManager)
    {
        public IActionResult Index()
        {
            return View(new LayoutModel<TestModel>(new TestModel(), "Test", sidebar));
        }
    }
}
