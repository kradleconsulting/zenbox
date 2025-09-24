using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.model;

namespace zenbox.web.Controllers
{
    [Authorize]
    [Route("/students")]
    public class StudentController(IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager) : BaseController(webHostEnvironment, userManager)
    {
        public IActionResult Index()
        {
            return View(new LayoutModel<StudentModel>(new StudentModel(), "Student", sidebar));
        }
    }
}
