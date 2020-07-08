using System;
using System.Net;
using System.IO;
using RedditClientViewer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RedditClientViewer.Data
{
    public static class Controller
    {
        public static void fetch(string callType)
        {
            /** BELOW IS A MODIFIED API GET METHOD SNIPPET*/
            var webRequest = (HttpWebRequest)WebRequest.Create(Api.Url);
            webRequest.Method = "GET";
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            var arr = JsonConvert.DeserializeObject<JObject>(s);
            Api.Data = arr;
            /* END OF SNIPPET*/
            if (callType.ToLower() == "posts") GetPostsAsync();
            if (callType.ToLower() == "reset") GetPostsAsync("reset");
        }
        public static void LoadMore()
        {
            Api.After = (string)Api.Data["data"]["children"].Last["data"]["name"];
            Api.Update();
        }


        public static void GetPostsAsync(string arg = "")
        {
            if (arg == "reset")
            {
                Api.Posts.Clear();
            }
            foreach (var child in Api.Data["data"]["children"])
            {
                var data = child["data"];

                var post = new RedditPost
                {
                    Author = (string)data["author"],
                    Domain = (string)data["domain"],
                    ID = (string)data["id"],
                    Link = (string)$"{Api.DOMAIN}{data["permalink"]}",
                    Name = (string)data["name"],
                    NumComments = (int)data["num_comments"],
                    Score = (int)data["score"],
                    Thumbnail = (string)data["thumbnail"],
                    Title = (string)data["title"],
                    Url = (string)data["url"],
                    Utc = (string)data["utc"],
                };
                if (post.Author != "PhotoShopBattles") Api.Posts.Add(post);
            }
        }

        public static string Timeago(string utc)
        {
            return utc;
        }
    }
}
