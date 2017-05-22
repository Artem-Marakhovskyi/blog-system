using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository.ArticleRepository.Interface;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository.ArticleRepository
{
    public class ArticleWriteRepository  : IArticleWriteRepository
    {
        private readonly BlogEntities context;

        public ArticleWriteRepository()
        {
            context = new BlogEntities();
        }
        /// <summary>
        /// Add new article to database
        /// </summary>
        /// <param name="article"></param>
        public void AddArticle(Article article)
        {
            foreach (var articleTag in article.Tags)
            {
                if (context.Tags.FirstOrDefault(e => e.Content.Equals(articleTag.Content)) == null)
                {
                    context.Tags.Add(new Tag()
                    {
                        Content = articleTag.Content.Replace(" ","_").ToLowerInvariant()
                    });
                }
            }
            context.SaveChanges();

            List<Tag> tags = new List<Tag>();
            foreach (var articleTag in article.Tags)
            {
                tags.Add(context.Tags.FirstOrDefault(e=>e.Content == articleTag.Content));
            }

            article.Tags = tags;

            context.Articles.Add(article);
            context.SaveChanges();
        }

        /// <summary>
        /// Delete article from Articles
        /// </summary>
        /// <param name="id"></param>
        public void DeleteArticle(int id)
        {
           var temp= context.Articles.FirstOrDefault(x => x.ArticleId == id);
            context.Articles.Remove(temp);
            context.SaveChanges();
        }
    }
}
