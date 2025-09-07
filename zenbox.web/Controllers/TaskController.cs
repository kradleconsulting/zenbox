using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zenbox.core.Interface;
using zenbox.model;

namespace zenbox.web.Controllers
{
    [Authorize]
    public class TaskController(UserManager<IdentityUser> userManager, ITaskService _taskService, IListService _listService) : BaseController(userManager)
    {
        private readonly ITaskService _taskService = _taskService;
        private readonly IListService _listService = _listService;

        public async Task<IActionResult> Index(Guid id)
        {
            var model = await _listService.GetList(id);

            if (model == null)
                return RedirectToAction("Index", "Home");

            return View(new LayoutModel<TasklistModel>(model, "Task"));
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskModel taskModel)
        {
            var model = await _taskService.AddTask(taskModel);

            return Ok(model);
        }

        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await _taskService.DeleteTask(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTask([FromBody] TaskModel taskModel)
        {
            var model = await _taskService.UpdateTask(taskModel);

            return Ok(model);
        }
    }
}
