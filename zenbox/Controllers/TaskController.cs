using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zenbox.core.Interface;
using zenbox.model;

namespace zenbox.web.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IListService _listService;

        public TaskController(ITaskService taskService,
                                IListService listService)
        {
            _taskService = taskService;
            _listService = listService;
        }


        public async Task<IActionResult> Index(Guid id)
        {
            var model = await _listService.GetList(id);

            if (model == null)
                return RedirectToAction("Index", "Home");

            return View(model);
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
