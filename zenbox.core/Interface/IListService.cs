using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zenbox.model;

namespace zenbox.core.Interface
{
    public interface ITaskListService
    {
        Task<TasklistCollectionViewmodel> GetLists(string userId);
        Task<TasklistViewmodel> GetList(Guid id);
        Task<TasklistViewmodel> AddList(TasklistViewmodel listModel);
        Task DeleteList(Guid id);
    }
}
