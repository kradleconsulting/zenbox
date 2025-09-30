using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.core.Interface;
using zenbox.model;

namespace zenbox.web.Controllers
{
    [Authorize]
    public class TasklistController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, ITaskListService listService) : BaseController(httpContextAccessor, webHostEnvironment, userManager)
    {
        private readonly ITaskListService listService = listService;

        [Route("/tasklists")]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            var model = await listService.GetLists(user.Id);

            return View(new LayoutModel<TasklistCollectionViewmodel>(model, "Tasklist", sidebar));
        }

        [HttpPost]
        public async Task<IActionResult> AddList(string name)
        {
            var user = await userManager.GetUserAsync(User);

            var model = new TasklistViewmodel
            {
                Name = name,
                OwnerId = user.Id
            };

            model = await listService.AddList(model);

            return Ok(model);
        }

        public async Task<IActionResult> DeleteList(Guid id)
        {
            await listService.DeleteList(id);

            return Ok();
        }
    }
}
