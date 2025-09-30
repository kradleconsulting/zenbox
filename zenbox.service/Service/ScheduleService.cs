using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using zenbox.core.Interface;
using zenbox.data;
using zenbox.model.Entity;

namespace zenbox.service
{
    public class ScheduleService(
        ITutorService tutorService, 
        IStudentService studentService,
        IDataService dataService
        ) : IScheduleService
    {
        public async Task<bool> Add(ScheduleEventModel eventModel)
        {
            await Task.FromException<NotImplementedException>(new NotImplementedException());

            return false;
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleEventModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ScheduleEventModel>> GetList(Guid userId)
        {
            return await dataService.GetSchedules(userId);
        }

        public Task<bool> Move(ScheduleEventModel eventModel)
        {
            throw new NotImplementedException();
        }
    }
}
