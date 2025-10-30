using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zenbox.model
{
    public class StudentViewmodel: IPageModel
    {
        public string Title { get; set; }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
