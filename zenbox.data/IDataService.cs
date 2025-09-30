
using zenbox.model.Entity;

namespace zenbox.data
{
    public interface IDataService
    {
        Task<List<ScheduleEventModel>> GetSchedules(Guid userId);
        Task<List<StudentModel>> GetStudents();
        List<TaskHeader> GetTaskHeaders();
        List<TaskLine> GetTaskLines(Guid headerId);
        Task<List<TutorModel>> GetTeachers();
    }
}