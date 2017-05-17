namespace DataAccessLayer.Entities
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string Login { get; set; }
        public string Comment { get; set; }
        public string Data { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
