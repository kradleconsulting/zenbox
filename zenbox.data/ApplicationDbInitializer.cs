using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using zenbox.model;

namespace zenbox.data
{
    public static class ApplicationDbInitializer
    {
        private static List<(string Name, string Password, string Role)> initialUsers = new List<(string Name, string Password, string Role)>()
        {
            ("abc@xyz.com", "Qwe123%", "Admin"),
            ("dfe@xyz.com", "Qwe123%", "Student"),
            ("ghi@xyz.com", "Qwe123%", "Tutor"),
        };

        private static List<string> initialStudents = new List<string>() { "Вася", "Петя", "Маша" };

        public static void SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (userManager == null || roleManager == null)
                return;

            foreach (var u in initialUsers)
                if (userManager.FindByEmailAsync(u.Name).Result == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        UserName = u.Name,
                        Email = u.Name,                        
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

            var u = userManager.FindByEmailAsync("dfe@xyz.com").Result;

            using (var db = new ZenboxDbContext())
            {
                if (u != null && !db.Students.Any())
                    foreach (var s in initialStudents)
                    {
                        db.Students.Add(new Student()
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

