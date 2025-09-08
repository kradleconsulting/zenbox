using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using zenbox.model;
using zenbox.web;

namespace zenbox.Pages
{
    public class IndexModel() : PageModel
    {
        public string Title { get; set; }

        public void OnGet()
        {
        }
    }
}
