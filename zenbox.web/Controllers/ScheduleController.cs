using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.core.Interface;
using zenbox.model;
using zenbox.model.Enums;
using zenbox.service;


namespace zenbox.web.Controllers
{
    [Authorize]
    [Route("/schedules")]
    public class ScheduleController(IScheduleService scheduleService, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager) : BaseController(httpContextAccessor, webHostEnvironment, userManager)
    {
        public async Task<IActionResult> Index()
        {

            var events = await scheduleService.GetList(Guid.Parse(currentUser.Id));
            if (currentUser.IsStudent)
                return View("Index", new LayoutModel<ScheduleViewmodel>(new ScheduleViewmodel() { Events = events }, "Schedule", sidebar ));
            else
                return View("Schedule", new LayoutModel<ScheduleViewmodel>(new ScheduleViewmodel(), "Schedule", sidebar));
        }


    }
}
