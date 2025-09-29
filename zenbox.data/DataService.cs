using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using zenbox.model;

namespace zenbox.data
{
    public class DataService
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

        public List<Teacher> GetTeachers()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Users.Join(db.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { u, ur })
                    .Join(db.Roles, ur => ur.ur.RoleId, r => r.Id, (ur, r) => new { ur.u, RoleName = r.Name })
                    .Where(r => r.RoleName == "Tutor")
                    .Select(ur => new Teacher
                    {
                        UserId = Guid.Parse(ur.u.Id),
                        Name = ur.u.UserName
                    }).ToList();
            }
        }

        public List<Schedule> GetSchedules()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Schedules.ToList();
            }
        }

        public List<Student> GetStudents()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Users.Join(db.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { u, ur })
                    .Join(db.Roles, ur => ur.ur.RoleId, r => r.Id, (ur, r) => new { ur.u, RoleName = r.Name })
                    .Where(r => r.RoleName == "Student")
                    .Select(ur => new Student
                    {
                        UserId = Guid.Parse(ur.u.Id),
                        Name = ur.u.UserName
                    }).ToList();
            }            
        }




    }
}
