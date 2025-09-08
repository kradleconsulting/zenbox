using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zenbox.model
{
    public class TasklistCollectionModel: IPageModel
    {
        public string Title { get; set; }

        public IEnumerable<TasklistModel> Items { get; set; }
    }
}
