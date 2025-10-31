using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
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
            var events = await scheduleService.GetList(currentUser);
            if (currentUser.IsStudent)
                return View("Index", new LayoutModel<ScheduleViewmodel>(new ScheduleViewmodel(), "Schedule", sidebar ));
            else
                return View("Schedule", new LayoutModel<ScheduleViewmodel>(new ScheduleViewmodel(), "Schedule", sidebar));
        }
        
        [Route("/events")]
        public async Task<IActionResult> Events()
        {
            var events = await scheduleService.GetList(currentUser);
            return Json(events);
        }

        [Route("/resources")]
        public async Task<IActionResult> Resources()
        {
            var user = await userManager.GetUserAsync(User);
            
            var resources = await scheduleService.GetResources(user);

            return Json(resources);
        }
    }
}
