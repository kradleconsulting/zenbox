using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zenbox.model
{
    public class TaskViewmodel: IPageModel
    {
        public string Title { get; set; }

        public Guid Id { get; set; }
        public Guid HeaderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Checked { get; set; }
    }
}
