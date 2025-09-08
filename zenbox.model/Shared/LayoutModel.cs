namespace zenbox.model
{
    public class LayoutModel<T> : ILayoutModel where T : IPageModel
    {
        public LayoutModel(T pageModel, string title, SidebarModel sidebar)
        {
            Title = title;

            Sidebar = sidebar;
            
            PageModel = pageModel;
        }
        
        public string Title { get; set; }

        public SidebarModel Sidebar { get; set; }

        public T PageModel { get; set; }

        IPageModel ILayoutModel.PageModel { get => PageModel; set => PageModel = (T)value; }
    }

    public interface ILayoutModel
    {
        string Title { get; set; }
        SidebarModel Sidebar { get; set; }
        IPageModel PageModel{ get; set; }
    }

    public interface IPageModel
    {
        string Title { get; set; }
    }

}
