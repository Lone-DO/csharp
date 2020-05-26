using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RedditViewer
{
    class Model
    {
        public static string Article(JToken data)
        {
            string card = "";
            var Title = data["data"]["title"];
            var Author = data["data"]["author"];
            var ID = data["data"]["id"];
            var Url = data["data"]["url"];
            var Link = data["data"]["permalink"];
            var Utc = data["data"]["created_utc"];
            var Thumbnail = data["data"]["title"];
            var Score = data["data"]["score"];
            var numComments = data["data"]["numComments"];

            card += $"<article id=\"{ID}card\">";
            card += $"<div id=\"Article-sidebar\" >";
            card += $"<button class=\"votebutton\" id=\"upvote\">UP</button>";
            card += $"<span id=\"Article.Score\">{Score}</span>";
            card += $"<button class=\"votebutton\" id=\"downvote\">DOWN</button>";
            card += $"</div>";
            card += $"<div id=\"Article-content\">";
            card += $"<div id=\"Article.information\">";
            card += $"<i id=\"Article.Author\">Posted by {Author}</i>";
            card += $"<i id=\"Article.Date\">{Utc} days ago</i>";
            card += $"</div>";
            card += $"<p id=\"Article.Title\">{Title}</p>";
            card += $"<img src={Url}>";
            card += $"<div id=\"Article-footer\">";
            card += $"<span id=\"Article.numComments\">{numComments} Comments</span>";
            card += $"<span>Share</span>";
            card += $"</div>";
            card += $"</div>";
            card += $"</article>";

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