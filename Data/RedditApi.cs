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
        private static string channel = "popular";
        private static JObject data;
        private static string after;
        private static string before;

        public static RedditPost[] Posts;
        public static RedditComment[] Comments;
        public static JObject Data { get => data; set => data = value; }

        public static string Url { get => url; set => url = $"{value}"; }
        public static string Sort { get => sort; set => sort = $"sort={value}"; }
        public static string Time { get => time; set => time = $"t={value}"; }
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
                    before = $"after={value}";
                    After = "";
                }
            } 
        }
        public static string Channel { get => channel; set => channel = $"{value}"; }
        public static string GeoLocation { get => geoLocation; set => geoLocation = $"geo_filter={value}"; }
        
        public static string Update()
        {
            string[] arr = {After, Before, GeoLocation, Time};
            var Options = "";

            foreach (var option in arr){
                if (!String.IsNullOrEmpty(option)) Options += $"?{option}";
            }

            string DOMAIN = "https://www.reddit.com/";
            //{self._default}{self._channel}{self.Sort}.json{self.Options['call']}
            Url = $@"{DOMAIN}{Channel}{Sort}.json{Options}";
            return DOMAIN;
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
            // if (callType.ToLower() == "posts") GetPostsAsync();
        }

        
        //    public static Task<RedditPost[]> GetPostsAsync()
        // {
        //     Task task;
        //     return task;
        //     // return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     // {
        //     //     Date = startDate.AddDays(index),
        //     //     TemperatureC = rng.Next(-20, 55),
        //     //     Summary = Summaries[rng.Next(Summaries.Length)]
        //     // }).ToArray());
        // }
        

    }
}
