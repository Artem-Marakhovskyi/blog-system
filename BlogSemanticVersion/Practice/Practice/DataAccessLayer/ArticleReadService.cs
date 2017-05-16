using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practice.Models;

namespace Practice.DataAccessLayer
{
    public class ArticleReadService   :IArticleReadService
    {
        private ContextEntities _context;

        public ArticleReadService(ContextEntities context)
        {
            _context = context;
        }

        public List<Article> GetArticle()
        {
            return _context.Articles.Where(x => x.Content.Length > 100).ToList();

        }
    }
}