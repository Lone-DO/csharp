using Newtonsoft.Json.Linq;
using RedditClientViewer.Data;

namespace RedditClientViewer.Model
{
    public class RedditComment
    {
        public string Author { get; set; }
        public int Score { get; set; }
        public string Utc { get; set; }
        public string Body { get; set; }
        public string Link { get; set; }
        public string Title
        {
            get => Regex.Match(Body, Regex.TITLE_REGEX, Regex.OPTIONS).ToString();
        }
        public string Src
        {
            get => Regex.Match(Body, Regex.URL_REGEX, Regex.OPTIONS).ToString();
        }
        public bool HasImage
        {
            get => Src.Contains(".png") || Src.Contains(".jpg");
        }
        public JToken Replies { get; set; }
    }
}
