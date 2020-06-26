using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using RedditClientViewer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RedditClientViewer.Data
{
    public static class Api
    {
        private static string sort = "hot/";
        private static string time;
        private static string url;
        private static string geoLocation;
        private static string channel = "";
        private static JObject data;
        private static JObject comments;
        private static string after;
        private static string before;
        

        public static string Sort { get => sort; set => sort = value; }
        public static string Time { get => time; set => time = value; }
        public static string Url { get => url; set => url = value; }
        public static string GeoLocation { get => geoLocation; set => geoLocation = value; }
        public static string Channel { get => channel; set => channel = value; }
        public static JObject Data { get => data; set => data = value; }
        public static JObject Comments { get => comments; set => comments = value; }
        public static string After { get => after; set => after = value; }
        public static string Before { get => before; set => before = value; }

        private static string[] Options = { After, Before, Time, GeoLocation };

        public static string Update()
        {
            string DOMAIN = "https://www.reddit.com/";
            Channel += "Hello ";
            //{self._default}{self._channel}{self.Sort}.json{self.Options['call']}
            Url = $@"{DOMAIN}{Channel}{Sort}.json{Options}";
            return DOMAIN;
        }
    }

    public static class Controller
    {
        public static void fetch()
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

            

        }

        /**
           public Task<RedditPost[]> GetPostsAsync()
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
             */

    }
}
