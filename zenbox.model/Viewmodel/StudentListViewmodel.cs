using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zenbox.model
{
    public class StudentListViewmodel : IPageModel
    {
        public string Title { get; set; }

        public IEnumerable<StudentViewmodel> Items { get; set; }
    }
}
