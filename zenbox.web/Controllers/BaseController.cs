using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using zenbox.data;

namespace zenbox.web.Controllers
{
    public class BaseController(UserManager<IdentityUser> userManager) : Controller
    {
        internal readonly UserManager<IdentityUser> userManager = userManager;
        internal readonly IdentityUser user;

        public BaseController(): this(null)
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
