using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zenbox.data
{
    public class Schedule
    {
        public Guid Id { get; set; } // Primary key
        public int EventId { get; set; } // Event identifier
        public string Text { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
