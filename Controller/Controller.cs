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
        }
        public static void LoadMore()
        {
            Api.After = (string)Api.Data["data"]["children"].Last["data"]["name"];
            Api.Update();
        }


        public static void GetPostsAsync()
        {
            foreach (var child in Api.Data["data"]["children"])
            {
                var data = child["data"];
                var post = new RedditPost
                {
                    Author = (string)data["name"],
                    Domain = (string)data["domain"],
                    Title = (string)data["title"],
                    ID = (string)data["id"],
                    Url = (string)data["url"],
                    Link = (string)$"{Api.DOMAIN}{data["permalink"]}",
                    Utc = (string)data["utc"],
                    Thumbnail = (string)data["thumbnail"],
                    Score = (int)data["score"],
                    NumComments = (int)data["num_comments"],
                };
                Api.Posts.Add(post);
            }
        }

        public static string Timeago(string utc)
        {
            return utc;
        }
    }
}
