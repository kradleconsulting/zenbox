using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using zenbox.core.Interface;
using zenbox.data;
using zenbox.model;
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


        public async Task<List<ScheduleEventModel>> GetList(ApplicationUser user)
        {
            if (user.IsTutor)
            {
                var tutor = await tutorService.GetByUserId(Guid.Parse(user.Id));

                return await dataService.GetTutorSchedules(tutor.Id);
            }
            else if (user.IsStudent)
            {
                var student = await studentService.GetByUserId(Guid.Parse(user.Id));
                
                return await dataService.GetStudentSchedules(student.Id);
            }

            return new List<ScheduleEventModel>();
        }

        public async Task<IEnumerable<ScheduleResourceModel>> GetResources(ApplicationUser user)
        {
            if (user.IsTutor)
            {
                var tutor = await tutorService.GetByUserId(Guid.Parse(user.Id));

                return await dataService.GetTutorResources(tutor.Id);
            }

            return new List<ScheduleResourceModel>();
        }

        public Task<bool> Move(ScheduleEventModel eventModel)
        {
            throw new NotImplementedException();
        }
    }
}
