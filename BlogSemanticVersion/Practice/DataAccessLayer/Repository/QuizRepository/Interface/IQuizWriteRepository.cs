using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository.QuizRepository.Interface
{
    public interface IQuizWriteRepository
    {
        void UpdateQuiz(Quiz quiz);
    }
}
