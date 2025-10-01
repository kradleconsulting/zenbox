using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace zenbox.model.Entity
{
    public class ScheduleEventModel
    {  //dp.events.list = [ { start: "2013-03-25T00:00:00", end: "2013-03-27T00:00:00", id: "1", text: "Event 1" }, { start: "2013-03-26T12:00:00", end: "2013-03-27T00:00:00", id: "2", text: "Event 2" } ]; dp.update();

        [JsonIgnore]
        public Guid TutorId { get; set; }
        
        [JsonIgnore]
        public Guid StudentId { get; set; }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
