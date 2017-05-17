using System.Linq;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository.FeedbackRepository.Interface;

namespace DataAccessLayer.Repository.FeedbackRepository
{
    public class FeedbackWriteRepository : IFeedbackWriteRepository
    {
        private readonly BlogEntities context;

        public FeedbackWriteRepository()
        {
            context = new BlogEntities();
        }

        /// <summary>
        /// add new feed to database
        /// </summary>
        /// <param name="feedback"></param>
        public void AddFeedback(Feedback feedback)
        {
            var article = context.Articles.First(e => e.ArticleId == feedback.ArticleId);
            article.Feedbacks.Add(feedback);

            context.SaveChanges();
        }
    }
}
