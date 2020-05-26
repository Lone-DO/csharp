using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RedditViewer
{
    class Model
    {
        public static string Article(JToken data)
        {
            string card;
            var Title = data["data"]["title"];
            var Author = data["data"]["author"];
            var ID = data["data"]["id"];
            var Url = data["data"]["url"];
            var Link = data["data"]["permalink"];
            var Utc = data["data"]["created_utc"];
            var Thumbnail = data["data"]["title"];

            // Console.WriteLine($"Title: {Title}");
            // Console.WriteLine($"Author: {Author}");
            // Console.WriteLine($"ID: {ID}");
            // Console.WriteLine($"Url: {Url}");
            // Console.WriteLine($"Link: {Link}");
            // Console.WriteLine($"Utc: {Utc}");
            // Console.WriteLine($"Thumbnail: {Thumbnail}");

            card = $"<img src={Url}>";

            // RENDER JSON INTO HTML SNIPPETS, 

            /*RETURN HTML
            <article class="Article.ID card">
                <div id="Article-sidebar">
                    <button class="votebutton" id="upvote">UP</button>
                    <span id="Article.Score"></span>
                    <button class="votebutton" id="downvote">DOWN</button>
                </div>
                <div id="Article-content">
                    <div id="Article.information">
                        <i id="Article.Author">Posted by @*Article.Author*@</i>
                        <i id="Article.Date">@*Article.Date*@ 2 days ago</i>
                    </div>
                    <p id="Article.Title">@*Article.Title*@</p>
                    <img src="Article.Url">
                    <div id="Article-footer">
                        <span id="Article.numComments">@*Article.numComments*@ Comments</span>
                        <span>Share</span>
                    </div>
                </div>
            </article>
            */
            return card;
        }
    }

}