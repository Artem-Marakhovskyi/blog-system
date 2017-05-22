using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository.ArticleRepository.Interface;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository.ArticleRepository
{
    public class ArticleReadRepository : IArticleReadRepository
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
            return context.Articles
                 .Include(e => e.Feedbacks)
                 .Include(e => e.UserArticleLikes)
                 .Include(e => e.Tags)
                 .FirstOrDefault(x => x.ArticleId.Equals(id));
        }

        public ICollection<Article> GetArticles(string tag)
        {
            if (tag == null)
            {
                return GetArticles();
            }
            tag = tag.ToLowerInvariant();
            var tagEntity = context.Tags.FirstOrDefault(e=>e.Content == tag);

            if (tagEntity == null)
            {
                return new List<Article>();
            }

            var articles = context.Articles.Include(e => e.Feedbacks)
                .Include(e => e.UserArticleLikes)
                .Include(e => e.Tags)
                .ToList();

            return articles.Where(e => e.Tags.Any(z => z.Content == tagEntity.Content)).ToList();
        }

        public ICollection<Article> GetArticles()
        {
            return context.Articles.Include(e => e.Feedbacks)
                .Include(e => e.UserArticleLikes)
                .Include(e => e.Tags)
                .ToList();

        }
    }
}
