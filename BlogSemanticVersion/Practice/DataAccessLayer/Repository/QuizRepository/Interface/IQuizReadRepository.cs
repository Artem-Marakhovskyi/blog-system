using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Repository.QuizRepository.Interface
{
    public interface IQuizReadRepository
    {
        List<Quiz> GetQuizes();
        double GetPercent(int id);
        int GetCountVote();
    }
}
