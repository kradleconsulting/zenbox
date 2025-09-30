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
                        TutorId = Guid.Parse(ur.u.Id),
                        Name = ur.u.UserName
                    }).ToListAsync();
            }
        }

        public async Task<List<ScheduleEventModel>> GetSchedules(Guid userId)
        {
            using (var db = new ZenboxDbContext())
            {
                return await db.Schedules
                    .Select(e => new ScheduleEventModel()
                    {
                        TutorId = e.TeacherId,
                        StudentId = e.StudentId,
                        EventStart = e.StartTime,
                        EventEnd = e.EndTime,
                    }).ToListAsync();
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
                        StudentId = Guid.Parse(ur.u.Id),
                        Name = ur.u.UserName
                    }).ToListAsync();
            }
        }
    }
}
