using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace RedditClientViewer.Model
{
    public class RedditComment
    {
        public string Author { get; set; }
        public int Score { get; set; }
        public string Utc { get; set; }
        public string Body { get; set; }
        public string Link { get; set; }
        public Match Title { get; set; }
        public Match Src { get; set; }
        public JToken Replies { get; set; }
    }
}
