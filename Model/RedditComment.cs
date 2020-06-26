using System;

namespace RedditClientViewer.Model
{
    public class RedditComment
    {
        string Data { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string ID { get; set; }
        string Url { get; set; }
        string Link { get; set; }
        string Utc { get; set; }
        string Thumbnail { get; set; }
        int Score { get; set; }
        int NumComments { get; set; }
        string Domain { get; set; }
    }
}
