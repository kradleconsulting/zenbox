using Microsoft.AspNetCore.Identity;

namespace zenbox.model
{
    

    public class SidebarModel
    {
        public List<SidebarMenuItem> Items { get; set; }
    }

    public class SidebarMenuItem {
        public string Title { get; set; }
        public List<string> Roles { get; set; }
        public string Link { get; set; }
        public string BootstrapIcon { get; set; }
        public int OrderNo { get; set; }        
    }
}
