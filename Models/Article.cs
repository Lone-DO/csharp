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
            card += $@"
            <article id='{ID} card'>
                <div id='Article-sidebar'>
                    <button class='votebutton' id='upvote'>UP</button>
                    <span id='Article.Score'>{Score}</span>
                    <button class='votebutton' id='downvote'>DOWN</button>
                </div>
                <div id='Article-content'>
                    <div id='Article.information'>
                        <i id='Article.Author'>Posted by {Author}</i>
                        <i id='Article.Date'>{Utc} days ago</i>
                    </div>
                    <p id='Article.Title'>{Title}</p>
                    <img src={Url}>
                    <div id='Article-footer'>
                        <span id='Article.numComments'>{numComments} Comments</span>
                        <span>Share</span>
                    </div>
                </div>
            </article>
            ";
            return card;
        }
    }

}