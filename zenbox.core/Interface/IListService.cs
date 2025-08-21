using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zenbox.model;

namespace zenbox.core.Interface
{
    public interface IListService
    {
        public Task<IEnumerable<ListModel>> GetLists(string userId);
        public Task<ListModel> GetList(Guid id);
        public Task<ListModel> AddList(ListModel listModel);
        public Task DeleteList(Guid id);
    }
}
