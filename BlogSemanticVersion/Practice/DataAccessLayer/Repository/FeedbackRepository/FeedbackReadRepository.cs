using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository.FeedbackRepository.Interface;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository.FeedbackRepository
{
    public class FeedbackReadRepository  : IFeedbackReadRepository
    {
        private readonly BlogEntities  context;

        public FeedbackReadRepository()
        {
            context = new BlogEntities();
        }

        /// <summary>
        /// Get all feeds from database
        /// </summary>
        /// <returns></returns>
        public ICollection<Feedback> GetFeedbacks()
        {
            return context.Feedbacks.ToList();
        }
    }
}
