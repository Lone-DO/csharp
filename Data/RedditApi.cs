using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using RedditClientViewer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace RedditClientViewer.Data
{
    public static class Api
    {
        private static string sort;
        private static string time;
        private static string url;
        private static string geoLocation;
        private static string channel = "r/popular";
        private static JObject data;
        private static string after;
        private static string before;

        public static List<RedditPost> Posts = new List<RedditPost>();
        public static RedditComment[] Comments;
        public static JObject Data { get => data; set => data = value; }

        public static string Url { get => url; set => url = $"{value}"; }
        public static string Sort { get => sort; set => sort = $"/{value}"; }
        public static string Time { get => time; set => time = $"t={value}"; }
        public static void SetSort(string value)
        {
            Sort = value;
        }
        public static string After { 
            get => after; 
            set {
                if (String.IsNullOrEmpty(value)) 
                {
                    after = "";
                }
                else 
                {
                    after = $"after={value}";
                    Before = "";
                }
            } 
        }
        public static string Before { 
            get => before; 
            set {
                if (String.IsNullOrEmpty(value)) 
                {
                    before = "";
                }
                else 
                {
                    before = $"before={value}";
                    After = "";
                }
            } 
        }
        public static string Channel { get => channel; set => channel = $"r/{value}"; }
        public static string GeoLocation { get => geoLocation; set => geoLocation = $"geo_filter={value}"; }
        
        public static void Update()
        {
            string[] arr = {After, Before, GeoLocation, Time};
            string DOMAIN = "https://www.reddit.com/";
            var Options = "";
            foreach (var option in arr){
                if (!String.IsNullOrEmpty(option)) Options += $"?{option}";
            }
            
            Url = $@"{DOMAIN}{Channel}{Sort}.json{Options}";
            Controller.fetch("posts");
        }

       
    }

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
                var post = new RedditPost{
                    Author = (string)data["name"],
                    Domain  = (string)data["domain"],
                    Title = (string)data["title"],
                    ID = (string)data["id"],
                    Url = (string)data["url"],
                    Link = (string)data["link"],
                    Utc = (string)data["utc"],
                    Thumbnail = (string)data["thumbnail"],
                    Score = (int)data["score"],
                    NumComments = (int)data["num_comments"],
                };
                Console.WriteLine(post);
                Api.Posts.Add(post);
            }
            Console.WriteLine(Api.Posts.Count);
        }
    }
}
