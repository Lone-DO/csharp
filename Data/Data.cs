using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// using RedditViewer.Controller;

namespace RedditViewer
{
    class Data
    {
        public static string _sort = "hot/";
        private static string _subReddit = $"r/photoshopbattles/{_sort}";
        public static string _after;

        public static string _url = $"https://www.reddit.com/{_subReddit}.json";
        // https://www.reddit.com/r/photoshopbattles/hot/.json
        public static JObject Response { get; set; }
        public static string Body;

        public void setSort(string Sort) => _sort = Sort.ToLower(); // Handle User Sort Selection
        public void setSub(string Channel) => _subReddit = Channel.ToLower(); // Handle User Channel: OPTIONAL

        public static void setAfter(string After) => _after = After;
        // On Call(), setAfter(article.id)  to _after, allowing Load() to add more data to Reponse.

        public static void Call()
        {
            // string _uri = "https://www.reddit.com/r/photoshopbattles/hot/.json";
            Controller.Fetch();

            Console.WriteLine($"LastChild: {_after}");
        }

    }
}