using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using zenbox.model.Enums;

namespace zenbox.model
{
    public class ApplicationUser: IdentityUser
    {
        [NotMapped]
        public IList<string> Roles { get; set; }

        public bool IsTutor { get { return Roles.Contains(UserRoles.Tutor.ToString()) && !Roles.Contains(UserRoles.Student.ToString()); } }

        public bool IsStudent { get { return Roles.Contains(UserRoles.Student.ToString()) && !Roles.Contains(UserRoles.Tutor.ToString()); } }
        

        //public string Login { get; set; }
        //public string Name { get; set; }
        //public string Surname { get; set; }
        //public Guid RoleId { get; set; }
        //public string Email { get; set; }        
    }
}
