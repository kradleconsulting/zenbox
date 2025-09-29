using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.model;
using zenbox.model.Enums;


namespace zenbox.web.Controllers
{
    [Authorize]
    [Route("/schedules")]
    public class ScheduleController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager) : BaseController(httpContextAccessor, webHostEnvironment, userManager)
    {
        public IActionResult Index()
        {
            if (currentUser.IsStudent)
                return View("Index", new LayoutModel<ScheduleModel>(new ScheduleModel(), "Schedule", sidebar));            
            else
                return View("Schedule", new LayoutModel<ScheduleModel>(new ScheduleModel(), "Schedule", sidebar));
        }
    }
}
