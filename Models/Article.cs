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
            var Data = data["data"];
            var Title = Data["title"];
            var Author = Data["author"];
            var ID = Data["id"];
            var Url = Data["url"];
            var Link = Data["permalink"];
            var Utc = Data["created_utc"];
            var Thumbnail = Data["title"];
            var Score = Data["score"];
            var numComments = Data["numComments"];
            var domain = Data["domain"];
            if (domain.ToString() != "self.photoshopbattles")
            {
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
                    </a>
                </article>
                ";
            }
            return card;
        }
    }

}