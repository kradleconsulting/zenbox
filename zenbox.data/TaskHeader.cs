using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zenbox.data
{
    public class TaskHeader
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public ICollection<TaskLine> Lines { get; set; }
    }
}
