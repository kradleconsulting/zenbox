using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.model;

namespace zenbox.web.Controllers
{
    [Authorize]
    public class MaterialController(IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager) : BaseController(webHostEnvironment, userManager)
    {
        public IActionResult Index()
        {
            return View(new LayoutModel<MaterialModel>(new MaterialModel(), "Material", sidebar));
        }
    }
}
