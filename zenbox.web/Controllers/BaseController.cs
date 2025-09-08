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
    public class BaseController(IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager) : Controller
    {
        internal readonly IWebHostEnvironment hostingEnvironment = hostingEnvironment;
        internal readonly UserManager<IdentityUser> userManager = userManager;
        internal readonly IdentityUser user;
        internal SidebarModel sidebar  => Utility.GetSidebarModel(Path.Combine(hostingEnvironment.WebRootPath, "json", "mainmenu.json"));

        public BaseController(): this(null, null)
        {
            user = userManager.GetUserAsync(HttpContext.User).Result;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //GetCurrentUser();
            //GetNotifications();

            base.OnActionExecuting(context);
        }
    }
}
