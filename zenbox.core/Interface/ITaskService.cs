
using zenbox.model;

namespace zenbox.core.Interface
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewmodel>> GetTasks(Guid id);
        Task<TaskViewmodel> GetTask(Guid id);
        Task<TaskViewmodel> AddTask(TaskViewmodel taskModel);
        Task DeleteTask(Guid id);
        Task<TaskViewmodel> UpdateTask(TaskViewmodel taskModel);
    }
}
