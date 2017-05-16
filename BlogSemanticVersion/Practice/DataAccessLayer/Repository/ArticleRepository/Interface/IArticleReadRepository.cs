using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository.ArticleRepository.Interface
{
    public interface IArticleReadRepository
    {
        ICollection<Article> GetArticles();
        Article GetArticleById(int id);
    }
}
