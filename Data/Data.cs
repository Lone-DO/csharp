using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            Fetch();
            Console.WriteLine($"LastChild: {_after}");
        }
        private static void Fetch()
        {
            /** BELOW IS A MODIFIED API GET METHOD SNIPPET*/
            var webRequest = (HttpWebRequest)WebRequest.Create(_url);
            webRequest.Method = "GET";  // <-- GET is the default method/verb, but it's here for clarity
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            var arr = JsonConvert.DeserializeObject<JObject>(s);
            Response = arr;
            /* END OF SNIPPET*/

            Parse("articles");
        }
        private static void Parse(string Type)
        {
            var Articles = Response["data"]["children"];
            int index = 0;

            if (Type == "articles")
            {
                foreach (var data in Articles)
                {
                    // Console.WriteLine($"{index}, {data["data"]["title"]}");
                    index += 1; // Incrementing children for length, to calculate last child
                    var Title = data["data"]["title"];
                    var Author = data["data"]["author"];
                    var ID = data["data"]["id"];
                    var Url = data["data"]["url"];
                    var Link = data["data"]["permalink"];
                    var Utc = data["data"]["created_utc"];
                    var Thumbnail = data["data"]["title"];

                    Console.WriteLine($"Title: {Title}");
                    Console.WriteLine($"Author: {Author}");
                    Console.WriteLine($"ID: {ID}");
                    Console.WriteLine($"Url: {Url}");
                    Console.WriteLine($"Link: {Link}");
                    Console.WriteLine($"Utc: {Utc}");
                    Console.WriteLine($"Thumbnail: {Thumbnail}");
                }
            }
            else if (Type == "comments")
            {
                foreach (var data in Articles)
                {
                    Console.WriteLine($"{index}, {data["data"]["title"]}");
                    index += 1; // Incrementing children for length, to calculate last child
                    var Title = data["data"]["title"];
                    var Author = data["data"]["author"];
                    var ID = data["data"]["id"];
                    var Url = data["data"]["url"];
                    var Link = data["data"]["permalink"];
                    var Utc = data["data"]["title"];
                    var Thumbnail = data["data"]["title"];

                    // Console.WriteLine($"Title: {Title}");
                    // Console.WriteLine($"Author: {Author}");
                    // Console.WriteLine($"ID: {ID}");
                    // Console.WriteLine($"Url: {Url}");
                    // Console.WriteLine($"Link: {Link}");
                    // Console.WriteLine($"Utc: {Utc}");
                    // Console.WriteLine($"Thumbnail: {Thumbnail}");
                }
            }

            if (index > 0) Data.setAfter(Response["data"]["children"][index - 1]["data"]["id"].Value<string>());
            Render();
        }
        private static void Render()
        {

            /*
            
            */
        }
    }
}