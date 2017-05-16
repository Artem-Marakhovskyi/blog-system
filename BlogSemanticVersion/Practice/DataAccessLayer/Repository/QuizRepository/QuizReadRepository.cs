using DataAccessLayer.Repository.QuizRepository.Interface;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Entities;
using System;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository.QuizRepository
{
    public class QuizReadRepository : IQuizReadRepository
    {
        private readonly BlogEntities context;

        public QuizReadRepository()
        {
            context = new BlogEntities();
        }

        /// <summary>
        /// Get common count of vote from "Best browser Quiz"
        /// </summary>
        /// <returns></returns>
        public int GetCountVote()
        {
            return context.Quizs.Sum(x => x.CountVote).Value;
        }

        /// <summary>
        /// Get percent of vote for current browser by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetPercent(int id)
        {
            var commonVote = GetCountVote();
            var currentCountVote = context.Quizs.FirstOrDefault(x => x.QuizId.Equals(id));
            return Math.Round(((double)currentCountVote.CountVote / commonVote) * 100, 3);
        }

        /// <summary>
        /// Get all quiz
        /// </summary>
        /// <returns></returns>
        public List<Quiz> GetQuizes()
        {
            return context.Quizs.ToList();
        }
    }
}
