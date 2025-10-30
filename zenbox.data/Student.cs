using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace zenbox.data
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }        
        public bool IsActive { get; set; }

        //What are student unique properties?

    }
}
