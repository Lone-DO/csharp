namespace RedditClientViewer.Model
{
    public class RedditComment
    {
        public string Data { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string Url { get; set; }
        public string Link { get; set; }
        public string Utc { get; set; }
        public string Thumbnail { get; set; }
        public int Score { get; set; }
        public int NumComments { get; set; }
        public string Domain { get; set; }
    }
}
