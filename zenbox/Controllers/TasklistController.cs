using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.core.Interface;
using zenbox.model;

namespace zenbox.web.Controllers
{
    [Authorize]
    public class TasklistController : Controller
    {
        private readonly IListService _listService;
        private readonly UserManager<IdentityUser> _userManager;

        public TasklistController(IListService listService, UserManager<IdentityUser> userManager)
        {
            _listService = listService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            var model = await _listService.GetLists(user.Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddList(string name)
        {
            var user = await _userManager.GetUserAsync(User);

            var model = new ListModel
            {
                Name = name,
                OwnerId = user.Id
            };

            model = await _listService.AddList(model);

            return Ok(model);
        }

        public async Task<IActionResult> DeleteList(Guid id)
        {
            await _listService.DeleteList(id);

            return Ok();
        }
    }
}
