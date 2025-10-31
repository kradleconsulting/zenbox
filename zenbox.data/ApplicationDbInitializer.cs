using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using zenbox.data;
using zenbox.data.Migrations;
using zenbox.model;
using static System.Net.Mime.MediaTypeNames;

namespace zenbox.data
{
    public static class ApplicationDbInitializer
    {
        private static List<(string Email, string Password, string Role)> initialUsers = new List<(string Email, string Password, string Role)>()
        {
            ("abc@xyz.com", "Qwe123%", "Admin"),
            ("d@xyz.com", "Qwe123%", "Student"),
            ("f@xyz.com", "Qwe123%", "Student"),
            ("e@xyz.com", "Qwe123%", "Student"),
            ("ghi@xyz.com", "Qwe123%", "Tutor"),
        };

        private static List<(string Email, string Name)> initialStudents = new List<(string Email, string Name)>() 
        { 
            ("d@xyz.com", "Вася"),
            ("f@xyz.com", "Петя"), 
            ("e@xyz.com", "Маша")
        };
        private static List<string> initialTeachers = new List<string>() { "Полина Евгеньевна"};

        public static void SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (userManager == null || roleManager == null)
                return;

            foreach (var u in initialUsers)
                if (userManager.FindByEmailAsync(u.Email).Result == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        UserName = u.Email,
                        Email = u.Email,                        
                        EmailConfirmed = true
                    };

                    IdentityResult userCreateResult = userManager.CreateAsync(user, u.Password).Result;
                    IdentityResult roleCreateResult = new IdentityResult();

                    if (userCreateResult.Succeeded)
                    {
                        var userRole = roleManager.FindByNameAsync(u.Role).Result;

                        if (userRole == null)                        
                            roleCreateResult = roleManager.CreateAsync(new IdentityRole(u.Role)).Result;
                        
                        if (userRole != null || roleCreateResult.Succeeded)
                            userManager.AddToRoleAsync(user, u.Role).Wait();
                        
                    }
                }            
        }

        public static void SeedTestStudents(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (userManager == null || roleManager == null)
                return;          

            using (var db = new ZenboxDbContext())
            {
                if (!db.Students.Any())
                    foreach (var s in initialStudents)
                    {
                        db.Students.Add(new Student()
                        {
                            Id = Guid.NewGuid(),
                            Name = s.Name,
                            UserId = Guid.Parse(userManager.FindByEmailAsync(s.Email).Result?.Id)
                        });

                        db.SaveChangesAsync().Wait();
                    }
            }
        }

        public static void SeedTestTeacher(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (userManager == null || roleManager == null)
                return;

            var u = userManager.FindByEmailAsync("ghi@xyz.com").Result;

            using (var db = new ZenboxDbContext())
            {
                if (u != null && !db.Teachers.Any())
                    foreach (var s in initialTeachers)
                    {
                        db.Teachers.Add(new Teacher()
                        {
                            Id = Guid.NewGuid(),
                            Name = s,
                            UserId = Guid.Parse(u.Id)
                        });
                        db.SaveChangesAsync().Wait();
                    }
            }
        }
    }
}

//--Truncate table Schedules
//--Truncate table Students
//--Truncate table Teachers
//--Truncate table AspNetUserRoles
//--Truncate table AspNetUserLogins
//--delete from AspNetUsers
//--delete from AspNetRoles


//INSERT
//[dbo].[Schedules]([Id], [StudentId], [TeacherId], [StartTime], [EndTime], [EventId], [Text])
//VALUES
//(NEWID(),
//N'EDE512D1-359F-480C-87F8-04EE809C3EC4',
//N'609E3D6F-B1BA-40DF-8093-AAC7868CAE3D',
//CAST(N'2025-11-04T14:00:00.0000000' AS DateTime2),
//CAST(N'2025-11-04T16:00:00.0000000' AS DateTime2),
//1,
//N'Srpski')

//INSERT[dbo].[Schedules]([Id], [StudentId], [TeacherId], [StartTime], [EndTime], [EventId], [Text])
//VALUES
//(NEWID(),
//N'EDE512D1-359F-480C-87F8-04EE809C3EC4',
//N'609E3D6F-B1BA-40DF-8093-AAC7868CAE3D',
//CAST(N'2025-11-07T14:30:00.0000000' AS DateTime2),
//CAST(N'2025-11-07T15:30:00.0000000' AS DateTime2),
//2,
//N'Srpski')

//INSERT
//[dbo].[Schedules]([Id], [StudentId], [TeacherId], [StartTime], [EndTime], [EventId], [Text])
//VALUES
//(NEWID(),
//N'AE4A63DE-5E6C-4FF9-9855-00A52F8E29E3',
//N'609E3D6F-B1BA-40DF-8093-AAC7868CAE3D',
//CAST(N'2025-11-05T11:00:00.0000000' AS DateTime2),
//CAST(N'2025-11-05T12:30:00.0000000' AS DateTime2),
//3,
//N'Hrvatski')

//INSERT[dbo].[Schedules]([Id], [StudentId], [TeacherId], [StartTime], [EndTime], [EventId], [Text])
//VALUES
//(NEWID(),
//N'AE4A63DE-5E6C-4FF9-9855-00A52F8E29E3',
//N'609E3D6F-B1BA-40DF-8093-AAC7868CAE3D',
//CAST(N'2025-11-07T12:30:00.0000000' AS DateTime2),
//CAST(N'2025-11-07T14:00:00.0000000' AS DateTime2),
//4,
//N'Hrvatski')

//INSERT
//[dbo].[Schedules]([Id], [StudentId], [TeacherId], [StartTime], [EndTime], [EventId], [Text])
//VALUES
//(NEWID(),
//N'0DEFC3E0-BEAF-4A99-8A75-8586404EC929',
//N'609E3D6F-B1BA-40DF-8093-AAC7868CAE3D',
//CAST(N'2025-11-03T10:00:00.0000000' AS DateTime2),
//CAST(N'2025-11-03T11:00:00.0000000' AS DateTime2),
//5,
//N'English')

//INSERT[dbo].[Schedules]([Id], [StudentId], [TeacherId], [StartTime], [EndTime], [EventId], [Text])
//VALUES
//(NEWID(),
//N'0DEFC3E0-BEAF-4A99-8A75-8586404EC929',
//N'609E3D6F-B1BA-40DF-8093-AAC7868CAE3D',
//CAST(N'2025-11-07T16:00:00.0000000' AS DateTime2),
//CAST(N'2025-11-07T17:00:00.0000000' AS DateTime2),
//6,
//N'English')