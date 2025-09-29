using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.model;

namespace zenbox.web.Controllers
{
    [Authorize]
    [Route("/materials")]
    public class MaterialController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager) : BaseController(httpContextAccessor, webHostEnvironment, userManager)
    {
        public IActionResult Index()
        {
            return View(new LayoutModel<MaterialModel>(new MaterialModel(), "Material", sidebar));
        }
    }
}
