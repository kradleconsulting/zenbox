using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zenbox.model;

namespace zenbox.core.Interface
{
    public interface ITaskListService
    {
        public Task<TasklistCollectionModel> GetLists(string userId);
        public Task<TasklistModel> GetList(Guid id);
        public Task<TasklistModel> AddList(TasklistModel listModel);
        public Task DeleteList(Guid id);
    }
}
