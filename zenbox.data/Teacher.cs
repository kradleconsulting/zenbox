using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zenbox.data
{
    public class Teacher
    {
        // Same, are there any unique properties for Teacher?
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
