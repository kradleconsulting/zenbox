using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zenbox.model.Entity
{
    public class ScheduleEventModel
    {
        public Guid TutorId { get; set; }
        public Guid StudentId { get; set; }

        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }

    }
}
