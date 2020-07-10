namespace RedditClientViewer.Model
{
    public class RedditComment
    {
        public string Author { get; set; }
        public int Score { get; set; }
        public string Utc { get; set; }
        public string Body { get; set; }
        public string Link { get; set; }
        public int NumReplies { get; set; }
    }
}
