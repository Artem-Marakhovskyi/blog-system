using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository.ArticleRepository.Interface;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository.ArticleRepository
{
    public class ArticleReadRepository  :IArticleReadRepository
    {
        private readonly BlogEntities context;

        public ArticleReadRepository()
        {
            context = new BlogEntities();
        }
        /// <summary>
        /// Get Article by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Article GetArticleById(int id)
        {
           return context.Articles.Include(e=>e.Feedbacks).Include(e=>e.UserArticleLikes).FirstOrDefault(x => x.ArticleId.Equals(id));
        }

        /// <summary>
        /// Get all articles from DataBase
        /// </summary>
        /// <returns></returns>
        public ICollection<Article> GetArticles()
        {
            return context.Articles.ToList();
        }
    }
}
