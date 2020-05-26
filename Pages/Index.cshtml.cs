using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RedditViewer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)

        {
            _logger = logger;
        }
        public static string Body;

        public void OnGet()
        {
            Data.Call();
        }
    }
}
