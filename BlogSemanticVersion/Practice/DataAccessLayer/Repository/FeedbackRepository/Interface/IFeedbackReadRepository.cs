using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository.FeedbackRepository.Interface
{
    public interface IFeedbackReadRepository
    {
        ICollection<Feedback> GetFeedbacks();
    }
}
