using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository.ArticleRepository.Interface
{
    public interface IArticleWriteRepository
    {
        void AddArticle(Article article);

        void DeleteArticle(int id);
    }
}
