using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using zenbox.model;

namespace zenbox.web
{
    public static class Utility
    {
        public static SidebarModel GetSidebarModel(string path)
        { // to be cached

            SidebarModel item = null;

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                item = JsonConvert.DeserializeObject<SidebarModel>(json);
            };

            return item;
        }
    }
}
