using System;
using System.Collections.Generic;
using RedditClientViewer.Model;
using Newtonsoft.Json.Linq;

namespace RedditClientViewer.Data
{
    public static class Api
    {
        private static string sort;
        private static string time;
        private static string url;
        private static string geoLocation;
        private static string channel = "r/photoshopbattles";
        private static JObject data;
        private static string after;
        private static string before;

        public static List<RedditPost> Posts = new List<RedditPost>();
        public static RedditComment[] Comments;
        public static string DOMAIN = "https://www.reddit.com";
        public static JObject Data { get => data; set => data = value; }

        public static string Url { get => url; set => url = $"{value}"; }
        public static string Sort { get => sort; set => sort = $"/{value}"; }
        public static string Time { get => time; set => time = $"t={value}"; }
        public static string Channel { get => channel; set => channel = $"r/{value}"; }
        public static string GeoLocation { get => geoLocation; set => geoLocation = $"geo_filter={value}"; }

        public static string After
        {
            get => after;
            set
            {
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
        public static string Before
        {
            get => before;
            set
            {
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

        public static void Update(string arg = "")
        {
            if (arg == "reset")
            {
                Controller.Reset();
            }
            string[] arr = { After, Before, GeoLocation, Time };
            var Options = "";
            foreach (var option in arr)
            {
                if (!String.IsNullOrEmpty(option)) Options += $"?{option}";
            }
            Url = $@"{DOMAIN}/{Channel}{Sort}.json{Options}";
            Controller.fetch("posts");
        }
    }
}
