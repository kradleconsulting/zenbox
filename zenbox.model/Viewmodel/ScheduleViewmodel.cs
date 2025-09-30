using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zenbox.model.Entity;

namespace zenbox.model
{
    public class ScheduleViewmodel: IPageModel
    {
        public string Title { get; set; }

        public List<ScheduleEventModel> Events { get; set; }
    }
}
