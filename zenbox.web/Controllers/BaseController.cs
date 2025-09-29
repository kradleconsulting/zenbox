using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using zenbox.data;
using zenbox.model;

namespace zenbox.web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        internal readonly IWebHostEnvironment hostingEnvironment;
        internal readonly SignInManager<ApplicationUser> signInManager;
        internal readonly UserManager<ApplicationUser> userManager;

        internal readonly ApplicationUser currentUser;
        internal SidebarModel sidebar  => Utility.GetSidebarModel(Path.Combine(hostingEnvironment.WebRootPath, "json", "mainmenu.json"));

        public BaseController(IHttpContextAccessor _httpContextAccessor, 
            IWebHostEnvironment _hostingEnvironment, 
            UserManager<ApplicationUser> _userManager)
        {
            hostingEnvironment = _hostingEnvironment;
            userManager = _userManager;
            httpContextAccessor = _httpContextAccessor;

            currentUser = userManager.GetUserAsync(httpContextAccessor.HttpContext.User).Result;
            currentUser.Roles = userManager.GetRolesAsync(currentUser).Result;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //GetCurrentUser();
            //GetNotifications();

            base.OnActionExecuting(context);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
                userManager.Dispose();                

            base.Dispose(disposing);
        }
    }
}
