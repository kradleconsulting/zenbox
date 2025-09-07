using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace zenbox.model
{
    public class LayoutModel
    {
        public LayoutModel(string title)
        {
            Title = title;

            
        }

        public string Title { get; }
    }

    public class LayoutModel<T> : LayoutModel
    {
        public LayoutModel(T pageModel, string title) : base(title)
        {
            PageModel = pageModel;
        }

        public T PageModel { get; }
    }
}
