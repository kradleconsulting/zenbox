
using zenbox.model.Entity;

namespace zenbox.data
{
    public interface IDataService
    {
        Task<List<ScheduleEventModel>> GetStudentSchedules(Guid studentId);
        Task<List<ScheduleEventModel>> GetTutorSchedules(Guid tutorId);
        Task<IEnumerable<ScheduleResourceModel>> GetTutorResources(Guid tutorId);
        Task<List<StudentModel>> GetStudents();
        List<TaskHeader> GetTaskHeaders();
        List<TaskLine> GetTaskLines(Guid headerId);
        Task<List<TutorModel>> GetTeachers();
    }
}