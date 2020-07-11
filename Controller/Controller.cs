using System;
using System.Net;
using System.IO;
using RedditClientViewer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace RedditClientViewer.Data
{
    public static class Controller
    {
        public static string Request(string req)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(req);
            webRequest.Method = "GET";
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            return reader.ReadToEnd();
        }
        public static void fetch(string callType, RedditPost post, string url)
        {
            var postLink = $"{(string)url}.json";
            string req = Request(postLink);
            var arr = JsonConvert.DeserializeObject<JArray>(req);
            Api.CommentData = arr;
            GetCommentsAsync(post);
        }
        public static void fetch(string callType)
        {
            string req = Request(Api.Url);
            var obj = JsonConvert.DeserializeObject<JObject>(req);
            Api.Data = obj;
            GetPostsAsync();
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

        public static void GetCommentsAsync(RedditPost post)
        {
            RegexOptions OPTIONS = RegexOptions.Multiline | RegexOptions.IgnoreCase;
            string URL_REGEX = @"ht(\w)+:\/\/(\w)+.(\w)+(\/)?(\w)+.(\w)+(\/?)(\w?)+(\.?)(\w?)+";
            // Created and tested @ https://regex101.com/r/MiGGnF/3
            string TITLE_REGEX = @"\[(.+)]";
            // Created and tested @ https://regex101.com/r/MiGGnF/4
            int index = Api.Posts.IndexOf(post);
            RedditPost Post = Api.Posts[index];

            foreach (var child in Api.CommentData[1]["data"]["children"])
            {
                var data = child["data"];
                bool IsComment = (string)child["kind"] != "more";
                bool IsNotDeleted = (string)data["author"] != "[deleted]";
                bool IsNotControversial = (int)data["score"] > 0;

                if (IsComment && IsNotDeleted && IsNotControversial)
                {
                    try
                    {
                        /** For DEBUGGING Json Data
                        Console.WriteLine($"Score Greater than 0? {(int)data["score"] > 0}");
                        Console.WriteLine($"Is Not Deleted? {(string)data["author"] != "[deleted]"}");
                        Console.WriteLine("Author:\t" + (string)data["author"]);
                        Console.WriteLine("Score:\t" + (int)data["score"]);
                        Console.WriteLine("UTC:\t" + (string)data["created_utc"]);
                        Console.WriteLine("Body:\t" + (string)data["body"]);
                        Console.WriteLine("Link:\t" + (string)$"{Api.DOMAIN}{data["permalink"]}");
                        Console.WriteLine("URL:\t" + Regex.Match((string)data["body"], URL_REGEX, OPTIONS));
                        Console.WriteLine("Title:\t" + Regex.Match((string)data["body"], TITLE_REGEX, OPTIONS));
                        Console.WriteLine("\n");
                        */

                        var comment = new RedditComment
                        {
                            Author = (string)data["author"],
                            Score = (int)data["score"],
                            Utc = (string)data["created_utc"],
                            Body = (string)data["body"],
                            Link = (string)$"{Api.DOMAIN}{data["permalink"]}",
                            Src = Regex.Match((string)data["body"], URL_REGEX, OPTIONS),
                            Title = Regex.Match((string)data["body"], TITLE_REGEX, OPTIONS),
                            Replies = data["replies"],
                        };
                        Api.Posts[index].Comments.Add(comment);
                    }
                    catch (ArgumentNullException)
                    {
                        // If Comment Cannot be parsed, catch error
                        return;
                    }
                }
            }
        }

        public static void Reset()
        {
            Api.Posts.Clear();
            Api.Before = "";
            Api.After = "";

        }
        public static string Timeago(string utc)
        {
            return utc;
        }
    }
}
