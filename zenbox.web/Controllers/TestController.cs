using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.model;

namespace zenbox.web.Controllers
{
    public class TestController(UserManager<IdentityUser> userManager) : BaseController(userManager)
    {
        public IActionResult Index()
        {
            return View(new LayoutModel<TestModel>(new TestModel(), "Test"));
        }
    }
}
