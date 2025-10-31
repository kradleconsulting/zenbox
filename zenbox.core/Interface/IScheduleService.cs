using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zenbox.model;
using zenbox.model.Entity;

namespace zenbox.core.Interface
{
    public interface IScheduleService
    {
        Task<List<ScheduleEventModel>> GetList(ApplicationUser user);
        Task<IEnumerable<ScheduleResourceModel>> GetResources(ApplicationUser user); 
        Task<ScheduleEventModel> Get(Guid id);
        Task<bool> Add(ScheduleEventModel eventModel);
        Task<bool> Delete(Guid id);
        Task<bool> Move(ScheduleEventModel eventModel);
    }
}
