using System;
namespace RedditViewer
{
    class Default
    {
        private class Data
        {
            public string Login { get; set; }
            public Object[] Api = { "", "" };
        }
        public class Api
        {
            public static string _sort = "hot/";
            public static string _subReddit = $"r/photoshopbattles/{_sort}";
            public static string _lastArticle;
            public static string _url = $"https://www.reddit.com/{_subReddit}.json";
            // https://www.reddit.com/r/photoshopbattles/hot/.json
            public Uri call = new Uri(_url);

            // public string Api { get; set; }
        }
    }
}