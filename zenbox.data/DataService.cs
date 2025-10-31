using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zenbox.model;
using zenbox.model.Entity;

namespace zenbox.data
{
    public class DataService : IDataService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DataService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public List<TaskHeader> GetTaskHeaders()
        {
            return new List<TaskHeader>();
        }

        public List<TaskLine> GetTaskLines(Guid headerId)
        {
            return new List<TaskLine>();
        }

        public async Task<List<TutorModel>> GetTeachers()
        {
            using (var db = new ZenboxDbContext())
            {
                return await db.Users.Join(db.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { u, ur })
                    .Join(db.Roles, ur => ur.ur.RoleId, r => r.Id, (ur, r) => new { ur.u, RoleName = r.Name })
                    .Where(r => r.RoleName == "Tutor")
                    .Select(ur => new TutorModel
                    {
                        Id = Guid.Parse(ur.u.Id),
                        Name = ur.u.UserName
                    }).ToListAsync();
            }
        }

        public async Task<List<ScheduleEventModel>> GetStudentSchedules(Guid studentId)
        {
            using (var db = new ZenboxDbContext())
            {
                return await db.Schedules
                    .Where(e => e.StudentId == studentId)
                    .Select(e => new ScheduleEventModel()
                    {
                        Id = e.EventId,
                        Text = e.Text,
                        TutorId = e.TeacherId,
                        StudentId = e.StudentId,
                        Start = e.StartTime,
                        End = e.EndTime,
                    }).ToListAsync();
            }
        }

        public async Task<List<ScheduleEventModel>> GetTutorSchedules(Guid tutorId)
        {
            using (var db = new ZenboxDbContext())
            {
                return await db.Schedules
                    .Where(e => e.TeacherId == tutorId)
                    .Select(e => new ScheduleEventModel()
                    {
                        Id = e.EventId,
                        Text = e.Text,
                        TutorId = e.TeacherId,
                        StudentId = e.StudentId,
                        Resource = e.StudentId,
                        Start = e.StartTime,
                        End = e.EndTime,
                    }).ToListAsync();
            }
        }

        public async Task<IEnumerable<ScheduleResourceModel>> GetTutorResources(Guid tutorId)
        {
            using (var db = new ZenboxDbContext())
            {
                return await db.Schedules
                    .Join(db.Students, s => s.StudentId, st => st.Id, (s, st) => new { s, st })
                    .Where(e => e.s.TeacherId == tutorId)                    
                    .Select(e => new ScheduleResourceModel()
                    {
                        Id = e.st.Id,
                        Name = e.st.Name
                    }).Distinct().ToListAsync();
            }
        }

        public async Task<List<StudentModel>> GetStudents()
        {
            using (var db = new ZenboxDbContext())
            {
                return await db.Users.Join(db.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { u, ur })
                    .Join(db.Roles, ur => ur.ur.RoleId, r => r.Id, (ur, r) => new { ur.u, RoleName = r.Name })
                    .Where(r => r.RoleName == "Student")
                    .Select(ur => new StudentModel
                    {
                        Id = Guid.Parse(ur.u.Id),
                        Name = ur.u.UserName
                    }).ToListAsync();
            }
        }
    }
}
