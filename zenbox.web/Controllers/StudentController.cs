using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.model;

namespace zenbox.web.Controllers
{
    public class StudentController(UserManager<IdentityUser> userManager) : BaseController(userManager)
    {
        public IActionResult Index()
        {
            return View(new LayoutModel<StudentModel>(new StudentModel(), "Student"));
        }
    }
}
