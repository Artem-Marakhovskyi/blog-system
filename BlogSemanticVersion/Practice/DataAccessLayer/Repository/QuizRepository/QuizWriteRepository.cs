using DataAccessLayer.Repository.QuizRepository.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository.QuizRepository
{
   public class QuizWriteRepository : IQuizWriteRepository
    {
        private readonly BlogEntities context;

        public QuizWriteRepository()
        {
            context = new BlogEntities();
        }

        /// <summary>
        /// Add vote for current quiz
        /// </summary>
        /// <param name="quiz"></param>
        public void UpdateQuiz(Quiz quiz)
        {
            var editQuiz = context.Quizs.Find(quiz.QuizId);
            editQuiz.CountVote++;
            context.Entry(editQuiz).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}