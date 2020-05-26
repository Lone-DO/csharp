using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace RedditViewer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string _uri = "https://www.reddit.com/r/photoshopbattles/hot/.json";
            var webRequest = (HttpWebRequest)WebRequest.Create(_uri);
            webRequest.Method = "GET";  // <-- GET is the default method/verb, but it's here for clarity
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            var arr = JsonConvert.DeserializeObject<JObject>(s);
            int i = 0;
            foreach (var data in arr["data"]["children"])
            {
                // Console.WriteLine($"{i}, {data["data"]}");
                Console.WriteLine($"{i}, {data["data"]["title"]}");
                i += 1;
            }
        }
    }
}
