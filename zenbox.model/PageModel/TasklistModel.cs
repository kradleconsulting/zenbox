using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zenbox.model
{
    public class TasklistModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }

        public List<TaskModel> Tasks = new List<TaskModel>();
    }
}
