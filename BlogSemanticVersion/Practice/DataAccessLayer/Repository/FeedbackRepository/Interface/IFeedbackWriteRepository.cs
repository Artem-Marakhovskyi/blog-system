using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository.FeedbackRepository.Interface
{
    public interface IFeedbackWriteRepository
    {
        void AddFeedback(Feedback feedback);
    }
}
